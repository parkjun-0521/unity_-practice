# A* Algorithm

## 찾게된 이유 
    Unity3D 에서는 NavMesh 하는 컴포넌트를 사용하여 길찾기 알고리즘을 쉽게 구현할 수 있는 것으로 알고 있다. 

    2D에서는 사용할 수 없는 컴포넌트이기 때문에 어떻게 구현을 해야될까 생각하면서 찾게된 알고리즘입니다.

## A* Algorithm 개요

    드론이나 인공지능 주행을 구현하기 위해 개발된 알고리즘입니다. 
    
    최단 경로를 찾는 알고리즘으로 유니티 2D에서 AI를 기반으로한 오브젝트를 만들 때 사용합니다. 
    유니티 3D에서는 Navigation Mesh를 사용하여 A* 알고리즘을 구현하지 않고 최단 경로 탐색할 수 있습니다. 

## A* Algorithm 이란

    A* 알고리즘은 주어진 출발 노드에서부터 목표 노드까지 가는 최단 경로를 찾아내는 그래프 탐색 알고리즘입니다.
    가장 짧은 경로를 찾기 위해 사용하는 알고리즘이며 다익스트라 알고리즘의 원리를 차용한 것으로
    A* 알고리즘은 현재 상태의 비용을 g(x), 현재에서 다음 상태로 이동할때 h(x) 라고 할 때 
    f(x) = g(x) + h(x) 가 최소가 되는 지점을 우선적으로 탐색하는 방법입니다. 

## A* Algorithm 비용 계산 

 <img src="https://github.com/parkjun-0521/unity_-practice/blob/main/Astar_Algorithm/Image/grid.PNG" width="20%" height="10%" /> 
 
 - 초록색 : Start Node
 - 빨간색 : End Node
 
 <img src="https://github.com/parkjun-0521/unity_-practice/blob/main/Astar_Algorithm/Image/Node.PNG" width="20%" height="10%" />  
 
 - 노드 한칸의 비용 표기  

 
g(n)은 출발 노드에서 현재 노드까지 이동하는데 드는 최소 비용을 말합니다.
여기서 g(n)의 값은 가로/세로 10, 대각선 14 입니다. 
피타고라스 정의에 의해 대각선의 길이는 $a^2+b^2=c^2$ 이므로, 가로/세로의 길이가 10인 대각선의 길이는 10√2 즉, 14.14... 에서 반올림하여 14가 됩니다. 
    
h(n)은 현재 노드에서 목표 노드까지 이동하는데 드는 비용을 말합니다. 
오직 가로/세로만으로 이동하여 드는 비용을 말합니다. 
    
f(n)은 g(n) + h(n) 의 비용을 말합니다. 이 값을 통해 경로를 탐색할 때 어느 노드가 가장 작은 비용을 가지고 있는지 판단하여 움직입니다. 
    
따라서 A* 알고리즘은 f(n)의 비용이 가장 작은 타일로 이동하여 길을 찾습니다. f(n)이 작은 모든 타일을 탐색하기 때문에 BFS 방식입니다. 

## A* Algorithm 구현 원리 

```ruby
OPEN                                                                               // OPEN Node ( 비어있고 열려있는 노드 )
CLOSED                                                                             // CLOSED Node ( 닫혀있는 노드 ) 
add the start node to OPEN                                                         // 시작 노드를 OPEN Nodex 을 추가 
                                                                                        
loop {                                                                             // 찾을 때 까지 loop 문을 돈다. ( while문 사용 )
    current = node in OPEN with the lowest f_cost                                  // 임의의 변수 current에 OPEN Node 중에서 f(n)의 값이 작은 것을 대입 ( 현재 노드 : current )
    remove current from OPEN                                                       // OPEN Node 에서 current 값을 제거 ( 작은 값으로 이동하기 때문에 current는 닫힌 노드가 된다 )
    add current to CLOSED                                                          // CLOSED Node에 current 값을 추가 ( 닫힌 노드가 된 current를 CLOSED에 추가 )

    if current is the target node                                                  // 현재 노드가 목표 노드를 찾았으면 종료 
        return

    foreach neighbour of the current node                                          // 목표 노드를 못찾았을 경우 현재 노드에서 이웃 노드를 탐색한다.         
        if neighbour is not traversable or neighbour is in CLOSED                  // 이웃 노드중에 통과할 수 없거나 닫힌 노드가 없는경우 ( 범위 안 && 장애물 없음 && CLOSED Nosd가 없는 경우 )
            skip to the next neighbour                                             // 다음 이웃 노드로 이동

        if new path to neighbour is shorter OR neighbour is not in OPEN            // 이동비용이 이웃노드의 g()보다 작거나 || OPEN에 이웃 노드가 없는 경우   
            set f_cost of neighbour                                                // 이웃 노드의 f() 비용을 설정한다. ( 먼저 g(), h() 비용을 계산하여 작업을 수행 )
            set patent of neighbour to current                                     // 현재 노드를 이웃 노드의 부모로 설정한다. 
            if neighbour is not in OPEN                                            // 이웃 노드가 열린 목록에 없을 경우 ( 즉, 닫힌 노드가 아닌경우 )
                add neighbour to OPEN                                              // 이웃 노드를 OPEN Node에 추가하고 이 작업을 계속 반복한다. 
}
```
  
