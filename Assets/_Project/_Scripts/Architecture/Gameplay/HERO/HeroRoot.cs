using UnityEngine;
using Zenject;

public class HeroRoot : MonoBehaviour
{
    public class Factory : PlaceholderFactory<HeroRoot> { }
}

