using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatFunctions
{
    private StatFunctions() { }
    public static long Health(ulong level) => 2 * (long)Mathf.Pow(level, 2.5f) + 10;

    public static long BossHealth(ulong level) => Health(level) + System.Convert.ToInt64(Random.Range(0, Health(level - 1) / 20));

    public static ulong Attack(long health) => (ulong)Mathf.Max(Mathf.CeilToInt(health / 20), 1);

    public static ulong XpToLevelUp(uint level) => 5 * (ulong)Mathf.Pow(level, 2.4f) + 10;
}
