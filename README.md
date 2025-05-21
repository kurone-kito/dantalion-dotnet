# 🦁 dantalion-dotnet

NuGet/VPM library and CLI sample app that calculates the personality
from the birthday.

see: [Dantalion for NPM](https://kurone-kito.github.io/dantalion/)

## System Requirements

- NuGet edition: .NET 8.x or later
- VPM edition: Unity 2022.3.22f1 and [VCC](https://vrchat.com/home/download) or [ALCOM](https://vrc-get.anatawa12.com/ja/alcom/)

## ▶ Getting Started

### 1. Import the registry via the VCC or ALCOM

**[Add to VCC](vcc://vpm/addRepo?url=https%3A%2F%2Fkurone-kito.github.io%2Fvpm%2Findex.json)**

### 2. Import the Dantalion package to your project

1. Click on the "Manage Project" button in the VCC
2. Find the "Dantalion" package and click on the "(+) Add package" button

### 3. Use the utilities, enjoy :D

```cs
using black.kit.dantalion;
using UnityEngine;

public class Example : UdonSharpBehaviour
{
    void Start()
    {
        // Get the birthday from the user
        var birthday = new DateTime(2000, 1, 1);

        // Calculate the personality
        var personality = Dantalion.GetPersonality(birthday);
        var inner = personality[(int)PersonalityIndex.Inner];
        var details = Dantalion.GetGeniusDetails((Genius)inner);
    }
}
```

For type definitions, please refer to the [Wiki of the TypeScript version](https://github.com/kurone-kito/dantalion/wiki/Types).

## Contributing

Welcome to contribute to this repository! For more details,
please refer to [CONTRIBUTING.md](.github/CONTRIBUTING.md).

## License

This repository is licensed under the [MIT License](LICENSE).
