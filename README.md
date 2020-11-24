# Graphs

### Программа для демонстрации различных алгоритмов поиска в графе

### Нацелено на платформу ```netcoreapp3.1```

### [Скачать](https://github.com/sampletext-hw/Graphs/releases/download/v1.0.0/Graphs.zip) готовое приложение

### Сборка
* ```git clone https://github.com/sampletext-hw/Graphs.git```
* ```cd Graphs```
* ```dotnet build```

### Информация
Все алгоритмы поиска наследуются от абстрактного алгоритма поиска [GraphSearch.cs](https://github.com/sampletext-hw/Graphs/blob/master/Graphs/GraphSearch.cs)
* Поиск в ширину [WideSearch.cs](https://github.com/sampletext-hw/Graphs/blob/master/Graphs/WideSearch.cs)
* Поиск в глубину [DeepSearch.cs](https://github.com/sampletext-hw/Graphs/blob/master/Graphs/DeepSearch.cs)
* Поиск алгоритмом Краскала [KraskalSearch.cs](https://github.com/sampletext-hw/Graphs/blob/master/Graphs/KraskalSearch.cs)
* Поиск алгоритмом Прима [PrimeSearch.cs](https://github.com/sampletext-hw/Graphs/blob/master/Graphs/PrimeSearch.cs)

### Использование
* Правой кнопкой мыши создаются узлы
* Левой кнопкой мыши выделяются узлы
* Чтобы передвинуть узлы - выделите необходимые и потяните мышкой в любом свободном месте
* F - создаёт соединения между выделенными узлами
* W [Wide] - выполняет Поиск в ширину
* D [Deep] - выполняет Поиск в глубину
* K [Kraskal] - выполняет Поиск алгоритмом Краскала
* P [Prime] - выполняет Поиск алгоритмом Прима
* S [Save] - сохраняет текущий граф в файл ```graph.bin``` в бинарном формате
* L [Load] - загружает граф из файла ```graph.bin```
