# Unity&C#으로 구현한 뱀서류 2D게임
* 개발인원 - 위규연

# 비동기 씬 전환
<img width = "20%" src = "https://github.com/noey-uyg/SurvivorCode/assets/105009308/675ac750-890c-4117-963e-377145144809"/>

- LoadingScene.cs에서 처리
- AsyncOperation operation = SceneManager.LoadSceneAsync("GameScene")로 GameScene을 비동기적으로 로드
- 씬 로드가 완전히 끝날 때까지 반복
- 진행 상황을 ProgressBar의 Value값으로 넣어 n% 로딩되었다고 알려줌
- ProgressBar의 Value가 100% 가득 찼다면 씬 전환을 시키고 코루틴을 종료함

# 소리 조절
<img width = "20%" src = "https://github.com/noey-uyg/SurvivorCode/assets/105009308/e377de52-6208-4112-b26f-add58b3ff60b"/>

- SoundManager.cs에서 처리
- 배경음 클릭시 배경음 관련 AudioSource를 mute
- 효과음 클릭시 효과음 관련 모든 AudioSource를 mute

# 스킬 구매
<img width = "20%" src = "https://github.com/noey-uyg/SurvivorCode/assets/105009308/ec88127a-a354-41d7-80a6-0bb2a5b7dc57"/>

# 스탯 강화
<img width = "20%" src = "https://github.com/noey-uyg/SurvivorCode/assets/105009308/4dde7a88-6979-4f4f-a06d-0330c699a7d8"/>

# 특성 강화
<img width = "20%" src = "https://github.com/noey-uyg/SurvivorCode/assets/105009308/b61c27f2-6d83-4fc5-8ed3-b0267647a8eb"/>
