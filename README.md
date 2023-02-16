# BanAsyncTaskAnalyzer

このアナライザーは[TDDで作るRoslynアナライザー](https://techcon2023.dena.dev/session/session3/)の発表の中で取り扱うデモアナライザーです。

BanAsyncTaskAnalyzerは、asyncメソッドの戻り値にvoid型、Task型を指定した場合、UniTaskへの置き換えを促すアナライザーです。

以下に、このアナライザーの診断項目を記します。

## BanAsyncTask0001: Banned use Task async method

| Item     | Value                |
|----------|----------------------|
| Category | BanAsyncTaskAnalyzer |
| Enabled  | True                 |
| Severity | Warning              |
| CodeFix  | False                |

asyncメソッドの戻り値が `System.Threading.Tasks.Task` だった場合、BanAsyncTask0001をレポートします。

```csharp
// bad
async Task BadMethodAsync()
{
}
// good
async UniTask GoodMethodAsync()
{
}
```

## BanAsyncTask0002: Banned void in async Method

| Item     | Value                |
|----------|----------------------|
| Category | BanAsyncTaskAnalyzer |
| Enabled  | True                 |
| Severity | Warning              |
| CodeFix  | False                |

asyncメソッドの戻り値が `System.Void` だった場合、BanAsyncTask0002をレポートします。

```csharp
// bad
async void BadMethodAsync()
{
}
// good
async UniTaskVoid GoodMethodAsync()
{
}
```

## How to build

Required: .NET SDK 5.0 or later

Build and create NuGet package.

```
$ dotnet build
```

## Reference

- [UniTask](https://github.com/Cysharp/UniTask.git)

---
Analyzer based on the [Roslyn Analyzer Template][template].

[template]: https://github.com/DeNA/RoslynAnalyzerTemplate
