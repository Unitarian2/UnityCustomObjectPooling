# UnityCustomObjectPooling
Unity'de Custom Object Pooling prototipini içeren bir repo'dur. Spawn sistemi Factory Design Pattern kullanılarak yazılmıştır.

Projenin sorunsuz çalışması için gerekli assetler :<br>
https://assetstore.unity.com/packages/3d/props/billiard-balls-set-244762 <br>
https://assetstore.unity.com/packages/3d/props/8-ball-pool-game-assets-3d-pack-125454

Class açıklamaları : 

---Factory Classes---
Factory.cs => Factory'ler için hazırlanan Base abstract class. Her farklı IBallProduct Factory'si GetProduct methodunu kullanır.
BouncyBallFactory.cs => BouncyBall tipinde bir prefab'i Pool'dan çağırır. Position ve Parent Object atamasını yapar. Son olarak Initialize methodunu çağırarak üretilen ürünün başlangıç methodu başlatılır. 
StickyBallFactory.cs => StickyBall tipinde bir prefab'i Pool'dan çağırır. Position ve Parent Object atamasını yapar. Son olarak Initialize methodunu çağırarak üretilen ürünün başlangıç methodu başlatılır. 

---Spawned Gameobject Classes---
BouncyBall.cs => Spawn edilen BouncyBallProduct ismindeki prefab'ler bu script'e sahiptir. Factory tarafında Initialize edildikten 10sn sonra PooledObject component'i üzerinden kendisini deaktif eder. 
StickyBall.cs => Spawn edilen StickyBallProduct ismindeki prefab'ler bu script'e sahiptir. Factory tarafında Initialize edildikten 10sn sonra PooledObject component'i üzerinden kendisini deaktif eder. 
IBallProduct.cs => Her farklı top tipi IBallProduct implemente eder.

---Managers---
BallSpawner.cs => Belirtilen hızda devamlı olarak rastgele bir top tipini spawn eder. Bunu yaparken Factory'lerden birini rastgele seçip GetProduct methodu ile spawn etme işlemini gerçekleştirir.

