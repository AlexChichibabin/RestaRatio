using System;

[Flags]
public enum ItemAbilityFlags
{
    None = 0,
    Cuttable = 1 << 0,
    Roastable = 1 << 1,
    Bakable = 1 << 2
}
