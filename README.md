# DobuCalculator

### by .net6.0

![sampleView](RepoData\titleImage.gif)

## About The Project

0.75% 확률에서 150번 뽑기를 시도했을 때, 아무것도 먹지 못할 확률 (도보 날 확률)은 대략 32.3% 정도로, 생각보다 큰 숫자지만. 수르젠 픽업 당시, 저는 그 사실을 몰랐기 때문에 "150뽑 정도면 명함 정도는 얻으려나?"라는 안일한 생각으로 가챠를 시도했고. 결국 망하고야 말았습니다.

처음 도부(=가챠가 망했다는 뜻)를 겪고, 쥬얼을 탕진했다는 충격에 휩싸여 2주간 우마무스메를 쉬면서 뽑기 확률에 대하여 고민해 보았고. 이항분포의 존재를 알게 되었습니다.

이 Dobu Calculator (도부 계산기)는 제가 했던 실수를 다른 사람들이 되풀이하지 않도록 도와주기 위해 만든 확률 계산기입니다. 시도 횟수(trial) & 확률(probability) & 성공 횟수(success)를 차례로 입력하면 해당 값에 대한 확률을 이항분포를 기반으로 계산해서 반환합니다.

누군가 말했던가요? 앞으로의 일을 각오한 사람은 행복하다고. 안일한 생각에는 각오가 없기 때문에 필연적으로 좌절과 불행이 따라올 수밖에 없습니다. 이 계산기가 누군가의 행복에 기여할 수 있기를 바랍니다. 모두 행복 가챠 하시길! 화이팅!!!

--

The probability of not eating anything (the probability of walking) is about 32.3% when you try to draw 150 times out of 0.75%, which is larger than you think. At the time of Surgen's pickup, I didn't know that, so I tried Gacha with complacent thoughts, "Would I get a business card if I picked 150?" It ended up being ruined.

After experiencing "Dobu"(=It means I didn't get anything) for the first time, I was shocked that I wasted Jewel, so I took a break from Umamusume for two weeks and thought about the probability of picking. You know the existence of a binomial distribution.

This Dobu Calculator is a probability calculator that I created to help others avoid repeating the mistakes I made. Enter trial & probability & success in order to calculate the probability for that value based on the binomial distribution and return it.

Did anyone say that? The person who is prepared for the future is happy. Because complacency is not determined, frustration and unhappiness inevitably follow. I hope this calculator can contribute to someone's happiness. I hope you get the prize without despair ! Good Luck!!!

## Built Info

[![DOTNET](https://img.shields.io/badge/.NET-6.0-Green)]()[![DOTNET](https://img.shields.io/badge/Nullable-enable-red)]()



## Getting Started

```bash
./Executable/DobuCalculator.exe
#You can Just double click that file in ./Executable
```

### or

```bash
git clone https://github.com/BaekNothing/DobuCalculator.git ./
cd DobuCalculator/DobuCalculator
dotnet run
```

### or

```bash
git clone https://github.com/BaekNothing/DobuCalculator.git ./
cd DobuCalculator/DobuCalculator
dotnet build
./bin/Debug/net6.0/Dobucalculator.exe
```



## Test Result

![File:testResult](RepoData\testResult.gif)

[![Tester](https://img.shields.io/badge/xUnit-v2.4.1-Green)]()[![Tester](https://img.shields.io/badge/Microsoft.NET.Test.Sdk-v16.11.0-Green)]()



## Contributing

- 이 프로젝트는 버그리포트, 제안, 이슈 등 모든 형태의 기여를 환영합니다. 🤣

- The project welcomes all forms of contribution, including bug reports, suggestions, and issues.
