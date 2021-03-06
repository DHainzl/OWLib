﻿using System;
using System.Collections.Generic;
using CASCLib;
using OWLib;
using OWLib.Types.STUD;

namespace OverTool {
    class ListNPC : IOvertool {
        public string Help => null;
        public uint MinimumArgs => 0;
        public char Opt => 'n';
        public string FullOpt => "list-npc";
        public string Title => "List NPCs";
        public ushort[] Track => new ushort[1] { 0x75 };
        public bool Display => true;

        public void Parse(Dictionary<ushort, List<ulong>> track, Dictionary<ulong, Record> map, CASCHandler handler, bool quiet, OverToolFlags flags) {
            List<ulong> masters = track[0x75];
            foreach (ulong masterKey in masters) {
                if (!map.ContainsKey(masterKey)) {
                    continue;
                }
                STUD masterStud = new STUD(Util.OpenFile(map[masterKey], handler));
                if (masterStud.Instances == null) {
                    continue;
                }
                HeroMaster master = (HeroMaster)masterStud.Instances[0];
                if (master == null) {
                    continue;
                }
                string heroName = Util.GetString(master.Header.name.key, map, handler);
                if (heroName == null) {
                    continue;
                }
                if (master.Header.itemMaster.key != 0) { // AI
                    InventoryMaster inventory = Extract.OpenInventoryMaster(master, map, handler);
                    if (inventory.ItemGroups.Length > 0 || inventory.DefaultGroups.Length > 0) {
                        continue;
                    }
                }
                Console.Out.WriteLine("{0} {1:X}", heroName, GUID.LongKey(masterKey));
            }
        }
    }
}
