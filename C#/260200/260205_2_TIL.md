1) 정리
```
CPU : 이 3D 모델들을 이 카메라 시점에서 그려줘(명령, 데이터 전달)
GPU : 알겠어. 
1. 3D를 2D로 변환(Vertex)하고 
2. 픽셀로 쪼개서(Rasterization), 
3. 색을 채워서 (Pixel/Fragment))화면에 보여줄게
```

## 2) GPU관점에서 RP를 처리하는 최소 단위

### 2-1) Vertex(점)
![alt text](image.png)
- 3D 공간상의 **한 점**을 의미합니다. 좌표(x,y,z)로 구성.
### Polygon(면, 다각형)
- Vertex(점)들이 모여 만들어지는 **최소의 면 단위**.
### Mesh(모델)
![alt text](image-1.png)
- **메시(Mesh)** : 면(Polygon)들의 집합 = 모델
```
-> GPU가 하는일

점(Vertex) -> 면(Polygon) -> 메시(Model)

GPU가 점의 위취를 우선적으로 계산, 

그 점들을 이어서 Polygon이라는 면을 만들어서 모델을 이루고,

최종적으로 Pixel에 색을 채워 넣는다.
```
![alt text](image-2.png)
- **Mesh Filter**   : 어떤 모양(Mesh)을 쓸 것인가?
- **Mesh Renderer** : 그 모양을 화면에 '그리는' 담당자.(Material 참조)
- **Material**      : 어떤 색과 질감을 그릴건데?

# 3. 게임 그래픽을 구성하는 핵심 요소

```
Texture, Material, Shader
```

## 3-1. Texture
+ UV Mapping
![alt text](image-3.png)
![alt text](image-4.png)

### 3-1-1. UV Mapping
- 3D 표면의 위치(점/면)와 2D 텍스처의 위치를 연결하는 과정.
  2D 이미지를 3D 물체 표면에 정확히 붙이는 방법이다.

### 3-1-2. Auto Mapping Tools
- blender, 마야 등등

## 3-2 Material
![alt text](image-5.png)
- 게임 화면에 보이는 질감을 담당합니다.
- 색상, 질감, 빛, 투명도 등 정보를 포함합니다.

## 3-3. Shader
- Material이 가진 Texture 혹은 색상 정보를 조합해서 화면에 최종적으로 질감을 입히는 역활!
- Shader(틀/설계도) : 어떤 데이털르 담을 **빈 칸 (속성)**을 가집니다.
  ![alt text](image-6.png)

# 4. 그래픽 처리 순서(게임 엔진)
![alt text](image-7.png)
## 4가지(거시적)
1. CPU 명령(Draw-Call)
   - CPU가 무엇을 그릴지 정해서 명령을 내리면, 
2. Vertex Shader
    - GPU가 그 물체의 점(Vertex)을 화면 위치에 맞게 옮김.
3. Rasterizer
    - 모니터 눈금에 맞춰 픽셀로 쪼갬.
4. Pixel/Fragment Shader
    - 마지막으로 그 칸들에 색을 채운다.
## 8가지(미시적)
- 1~3 단계
  1. CPU & Draw-Call
      - CPU가 GPU에게 그려라!
      - 메시(Mesh), 머테리얼(Material)
  2. Vertex Shader(정점 연산)
      - 3D 공간에 있는 어떤 메시/모델을 2D화면에 위치 시키는 녀석.
  3. Culling
      - 불필요한 영역을 계산에서 지워버려.
      - 3가지
        - [Default로 제공]
        - 프로스텀 컬림(CPU) : 카메라 시야 아예 밖에 있어? (시야 밖 통째로 버림)
        - 백페이스 컬링(GPU) : 물체 면의 방향이 카메라 반대편을 보고 있냐?
      - [직접 설정]
        - 오클루전 컬링(CPU/GPU) : 앞에 있는 물체에 완전히 가려졌는가?
![alt text](image-8.png)
- 4~5 단계(비주얼 담당 = 색칠하기)
  
  4. Rasterizer
      - 출력될 픽셀 조각들로 쪼개는 과정임
      - 계단 현상이 발생함
  5. pixel/Fragment Shader
      - 실제 색을 입히는 단계
- 6~7 단계
  
  6. Depth Test(Z-test)
       - 그려지는 우선순위 = 오브젝트 앞뒤 판별
  7. Blending
        - 배경하고 어떻게 섞일까? 앞뒤 판별이 끝난 후, 배경색 + 현재 픽셀 합성

- 8 단계
  
  8. Post-Processing

## Unity가 가지고 가는 RP이해하기(Forward)
1) Built-in Pipeline(Legacy)
![alt text](image-9.png)
   - 개발자가 내부 구조를 수정할 수 없음
   - 유니티에서 제공해주는 옵션 조장만 가능

1) SRP(Scriptable-Render-Pipeline)
   -> 기반 템플릿 URP/HDRP
    ![alt text](image-10.png)
    - Built-int 한계?
    - SRP 초기 : C#, HLSL 언어(2018)
    - SRP 기반 템플릿 -> URP/HDRP(2019)
  - ![alt text](image-11.png)

### 그래서 URP 장점은??
- SRP Batcher(드로우 콜 최적화)
- Forward+
- GPU Resident Drawer
![alt text](image-12.png)

1) Forward Render Pipeline
   - 오브젝트를 그릴 때 조명을 그떄그때 계산함
2) Deffered Render Pipeline
   - 먼저 화면에 필효한 정보들을 저장
     - 위치
     - 노멀
     - 머테리얼