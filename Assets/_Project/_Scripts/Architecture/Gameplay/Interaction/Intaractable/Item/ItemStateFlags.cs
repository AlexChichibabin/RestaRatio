using System;

[Flags]
public enum ItemStateFlags
{
    None = 0,
    Cutted = 1 << 0,
    Roasted = 1 << 1,
    Baked = 1 << 2,
	Burnt = 1 << 3
}
