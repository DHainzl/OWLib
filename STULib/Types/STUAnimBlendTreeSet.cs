// File auto generated by STUHashTool

using STULib.Types.AnimationList.x021;
using static STULib.Types.Generic.Common;

namespace STULib.Types {
    [STU(0xFC47A2ED, "STUAnimBlendTreeSet")]
    public class STUAnimBlendTreeSet : STUInstance {
        [STUField(0x0D7DD9D2)]
        public STUVec3A m_0D7DD9D2;

        [STUField(0x8D0B5147)]
        public STUVec3A m_8D0B5147;

        [STUField(0x93DA6E7C, "m_hardcodedAnimCategoryRefs")]
        public STUAnimBlendTreeSet_HardcodedAnimCategoryRefs HardcodedAnimCategoryRefs;

        [STUField(0x8610C654)]
        public STUGUID Skeleton;

        [STUField(0x2ADF6453)]
        public STU_E779B62B[] m_2ADF6453;

        [STUField(0x85CC326B)]
        public STU_DF9B7DE2 m_85CC326B;

        [STUField(0x6DDF40DD, "m_bonePoseOverrideItems")]
        public STUAnimBlendTreeSet_BonePoseOverrideItem[] BonePoseOverrideItems;

        [STUField(0x253EE7C8, ForceNotBuffer = true, Demangle = false)]
        public STUGUID[] GUIDx014Array;

        [STUField(0x6AFCD1A5, "m_blendTreeItems")]
        public STUAnimBlendTreeSet_BlendTreeItem[] BlendTreeItems;

        [STUField(0xF9CA7995)]
        public uint[] m_F9CA7995;

        [STUField(0x52096082)]
        public uint[] m_52096082;

        [STUField(0x818E5217)]
        public STU_978A87DE[] m_818E5217;

        [STUField(0xC5413AED)]
        public STU_CE2BEF36[] m_C5413AED;

        [STUField(0x85453F7B)]
        public STUGUID[] m_85453F7B;  // STU_CB5A89D2

        [STUField(0xE1FA44F9, ForceNotBuffer = true, Demangle = false)]
        public STUGUID[] References;

        [STUField(0x2B2C5C7F, EmbeddedInstance = true)]
        public STU_72C48DD7 m_2B2C5C7F;

        [STUField(0x144318D5, EmbeddedInstance = true)]
        public STU_2BA91EC5 m_144318D5;

        [STUField(0xBA53D5ED, Demangle = false)]
        public STUGUID SecondaryList;

        [STUField(0x84935843, Demangle = false)]
        public STUGUID GUIDx014;

        [STUField(0x384DE14F, "m_retargetParams")]
        public STUAnimBlendTreeSet_RetargetParams RetargetParams;

        [STUField(0x29EFF18D)]
        public uint m_29EFF18D;
    }
}
