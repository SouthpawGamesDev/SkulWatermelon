- 모노를 하나만 쓸때 협력하는 객체들을 만드는 경우 그 객체들에게 Mono와 관련되어있는 값들을 주입하기 위해서는 결국 Mono에서 모든걸 주입해줘야하는 문제가 있었음
  - 모노가 아닌 객체도 Serialize 해서 직접 받을 수 있는 방법으로 해결

* 리소스 생명주기를 관리해주는 녀석이 필요.

* 폴리 콜라이더 때문에 프리팹으로 변경 후 데이터 저장 했음.

  * 리소스 매니저도 프리팹으로 저장해두게 바꾸었음.

    -> 기존의 데이터를 그대로 가지고 있고, 데이터가 프리팹을 물게 하는 구조가 더 좋아 보인다.

    -> 그런데 이미 프리팹을 데이터로 바라보고 사용하고 있음으로 새로운 데이터가 오거나 변경이 생겨도 프리팹을 바꾸는것이 훨씬 변경이 용이하고 편하다. 그러므로 상태 유지.

* HeadGenerator의 싱글톤일 필요가 있을까?

  * HeadGenerator 생애 주기를 파악한다 -> 게임의 시작과 끝까지만 존재하면 된다.
    * 즉, 싱글톤일 필요가 없다. (타이틀 화면 등에서 살아 있을 필요가 없다.)

* 생애 주기를 관리하는 녀석만이 싱글톤이고 그 녀석 아래에 HeadGenerator등이 있으면 좋을 듯

  * GameManager가 GameCycle을 만들고

  * GameCycle이 아래를 만든다.

    * HeadGenerator

    * Score

      

* **SceneBinder를 만들어서 씬을 불렀을때 필요한 데이터를 정리하고 연결하는 역할을 함.** 

* **Evolution 클래스가 스태틱이기 보다는 다른 객체를 만들어서 하는게 좋아 보인다.**

* **static한 event는 위험하다. 다른 곳으로 옮기자.**

---

## 11/11

- GameManager를 상위 단계로 올리고 그 아래 StageManager를 만들어서 Stage에 관련된 데이터만 StageManager에서 관리하도록 수정하였음
- Player를 없앴음
  - Player가 하는일이 명확하지 않아서
- 다음 시간에 Evolution Observer를 만들꺼임
  - EO는 Head들을 들고있고 Head들이 충돌될경우 EO에게 알려줌
  - GameCycle이 EO를 업데이트하면 진화검사 후 진화

---

## 11/25

Evoltuion을 어떻게 만들까?

- 방법1 : Head가 EventQueue같은 곳에 충돌 이벤트를 발생시키고 Evolutioner가 그 EventQueue를 바라본다
  - 질문 : Head가 EventQueue를 바라봐도 되는가?
  - 답변 : 말단이라서 더 괜찮다



- 방법2 : Head가 충돌이벤트를 발생하고 외부에서 직접 구독을 한다
  - 질문 : Evolutioner랑 HeadGenrerator가 서로가 서로에게 연관이 되어있다
  - 답변 : 서로가 연관이 되어있는 경우에는 두 가지 방법이 있을 것 같다. 더 위층의 레이어를 두고 교통정리를 하는 방법, 두 관계간의 중간자를 둬서 교통정리를 하는 방법, 둘다 해보고 넘어가는게 좋을 것 같다