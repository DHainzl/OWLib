// File auto generated by STUHashTool

using STULib.Types.Statescript.Components;
using STULib.Types.Statescript.Components.Enums;
using static STULib.Types.Generic.Common;

namespace STULib.Types {
    [STU(0x73BB2F3A, "STUEntityDefinition")]
    public class STUEntityDefinition : STUInstance {
        [STUField(0x8B9A461F)]
        public STUGUID m_8B9A461F;  // STUEntityDefinition

        [STUField(0x04A8896C)]
        public STUGUID m_04A8896C;  // STUEntityDefinition

        [STUField(0xF29E4995)]
        public STUChildEntityDefinition[] Children;

        [STUField(0x8AF8F4F5)]
        public STUHashMap<STUEntityComponent> Components;  // key = instance checksum

        [STUField(0x87916047)]
        public STUEnum_790E517D m_87916047;
    }
}