리스트와 링크드리스트

가장 단순한 형태인 리스트

List<T>
LinkedList<T>
순차 자료구조 연결 자료구조의 차이점

List<string> list = new();

list.Add("De");

list.Insert(1, "Velo");

// 삭제
// 맨뒤의 데이터를 삭제할 때 o(1)
중간 데이터 삭제 O(n)

list.Remove
list.RemoveAt

// 검색

if(list.Contains("De"))
