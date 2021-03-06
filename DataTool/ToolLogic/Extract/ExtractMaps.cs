﻿using System;
using System.Collections.Generic;
using DataTool.Flag;
using DataTool.Helper;
using DataTool.SaveLogic;
using DataTool.ToolLogic.List;
using STULib.Types;
using static DataTool.Program;
using static DataTool.Helper.STUHelper;
using static DataTool.Helper.Logger;

namespace DataTool.ToolLogic.Extract {
    [Tool("extract-maps", Description = "Extract maps", TrackTypes = new ushort[] {0x9F, 0x0BC}, CustomFlags = typeof(ExtractFlags))]
    public class ExtractMaps : QueryParser, ITool, IQueryParser {
        public void IntegrateView(object sender) {
            throw new NotImplementedException();
        }

        public void Parse(ICLIFlags toolFlags) {
            SaveMaps(toolFlags);
        }
        
        protected override void QueryHelp(List<QueryType> types) {
            IndentHelper indent = new IndentHelper();
            Log("Please specify what you want to extract:");
            Log($"{indent+1}Command format: \"{{map name}}\" ");
            Log($"{indent+1}Each query should be surrounded by \", and individual queries should be seperated by spaces");
            
            
            Log($"{indent+1}Maps can be listed using the \"list-maps\" mode");
            Log($"{indent+1}All map names are in your selected locale");
            
            Log("\r\nExample commands: ");
            Log($"{indent+1}\"Kings Row\"");
            Log($"{indent+1}\"Ilios\" \"Oasis\"");
        }

        public void SaveMaps(ICLIFlags toolFlags) {
            string basePath;
            if (toolFlags is ExtractFlags flags) {
                basePath = flags.OutputPath;
            } else {
                throw new Exception("no output path");
            }
            
            Dictionary<string, Dictionary<string, ParsedArg>> parsedTypes = ParseQuery(flags, QueryTypes, QueryNameOverrides);
            if (parsedTypes == null) {QueryHelp(QueryTypes); return;}
            foreach (ulong key in TrackedFiles[0x9F]) {
                STUMap map = GetInstance<STUMap>(key);
                if (map == null) continue;
                ListMaps.MapInfo mapInfo = ListMaps.GetMap(key);
                
                Dictionary<string, ParsedArg> config = new Dictionary<string, ParsedArg>();
                foreach (string name in new [] {mapInfo.Name, mapInfo.NameB, mapInfo.UniqueName, "*"}) {
                    if (name == null) continue;
                    string theName = name.ToLowerInvariant();
                    if (!parsedTypes.ContainsKey(theName)) continue;
                    foreach (KeyValuePair<string,ParsedArg> parsedArg in parsedTypes[theName]) {
                        if (config.ContainsKey(parsedArg.Key)) {
                            config[parsedArg.Key] = config[parsedArg.Key].Combine(parsedArg.Value);
                        } else {
                            config[parsedArg.Key] = parsedArg.Value.Combine(null); // clone for safety
                        }
                    }
                }
                
                if (config.Count == 0) continue;
                
                Map.Save(flags, map, key, basePath);
            }
        }

        public List<QueryType> QueryTypes => new List<QueryType> {new QueryType {Name = "MapFakeType"}};
        public Dictionary<string, string> QueryNameOverrides => new Dictionary<string, string>();
    }
}