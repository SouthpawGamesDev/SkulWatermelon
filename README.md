- 모노를 하나만 쓸때 협력하는 객체들을 만드는 경우 그 객체들에게 Mono와 관련되어있는 값들을 주입하기 위해서는 결국 Mono에서 모든걸 주입해줘야하는 문제가 있었음
  - 모노가 아닌 객체도 Serialize 해서 직접 받을 수 있는 방법으로 해결

* 리소스 생명주기를 관리해주는 녀석이 필요.