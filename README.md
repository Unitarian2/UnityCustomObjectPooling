# UnityCustomObjectPooling
Unity'de Custom Object Pooling prototipini içeren bir repo'dur. Spawn sistemi Factory Design Pattern kullanılarak yazılmıştır.

Projenin sorunsuz çalışması için gerekli assetler :<br>
https://assetstore.unity.com/packages/3d/props/billiard-balls-set-244762 <br>
https://assetstore.unity.com/packages/3d/props/8-ball-pool-game-assets-3d-pack-125454

Class açıklamaları : <br><br>

---Pool Classes---<br>
<b>PoolElement.cs =></b> Pool içerisinde PoolElement tipinde nesneler tutuyoruz. Yeni türde pool'lar oluşturmayı kolaylaştırmak adına Generic property'lere sahip şekilde tanımladık.<br>
<b>PooledObject.cs =></b> Pool edilen Gameobject datasıdır. Release fonksiyonu çalıştırıldığında ilgili Gameobject'i Pool listesine geri gönderir.

---ObjectPool.cs---<br>
Object Pool methodları açıklamaları aşağıdaki gibidir:<br>
<b>pooledObjectList =></b> Pool Listesi. PoolObjectType'ı Key olarak kullanıyoruz. PooledObject ise Pool edilmiş GameObject datasını temsil eder.<br>
<b>SetupPool =></b> ObjectPool sınıfı ilk yüklendiğinde, initPoolSize kadar prefab'i önceden Instantiate edip Pool'a ekler ve bir ön yükleme yapar.<br>
<b>GetPooledObject =></b> Pool'dan verilen PoolObjectType'daki topu ilgili Factory'e gönderir. Eğer istenen PoolObjectType'da bir top yoksa yenisini Instantiate eder ve return eder, varsa pooledObjectList'den birtanesini alır ve return eder.<br>
<b>ReturnToPool =></b> Verilen topu pooledObjectList'e ekler ve gameobject'ini inactive yapar. Pool MaxSize'a ulaşmışsa Destroy eder. Duplicate olmaması için sadece pooledObjectList'de olmayan topu listeye geri alır.<br><br>

---Factory Classes---<br>
<b>Factory.cs =></b> Factory'ler için hazırlanan Base abstract class. Her farklı IBallProduct Factory'si GetProduct methodunu kullanır.<br>
<b>BouncyBallFactory.cs =></b> BouncyBall tipinde bir prefab'i Pool'dan çağırır. Position ve Parent Object atamasını yapar. Son olarak Initialize methodunu çağırarak üretilen ürünün başlangıç methodu başlatılır. <br>
<b>StickyBallFactory.cs =></b> StickyBall tipinde bir prefab'i Pool'dan çağırır. Position ve Parent Object atamasını yapar. Son olarak Initialize methodunu çağırarak üretilen ürünün başlangıç methodu başlatılır. <br><br>

---Spawned Gameobject Classes---<br>
<b>BouncyBall.cs =></b> Spawn edilen BouncyBallProduct ismindeki prefab'ler bu script'e sahiptir. Factory tarafında Initialize edildikten 10sn sonra PooledObject component'i üzerinden kendisini deaktif eder. <br>
<b>StickyBall.cs =></b> Spawn edilen StickyBallProduct ismindeki prefab'ler bu script'e sahiptir. Factory tarafında Initialize edildikten 10sn sonra PooledObject component'i üzerinden kendisini deaktif eder. <br>
<b>IBallProduct.cs =></b> Her farklı top tipi IBallProduct implemente eder.<br><br>

---Managers---<br>
<b>BallSpawner.cs =></b> Belirtilen hızda devamlı olarak rastgele bir top tipini spawn eder. Bunu yaparken Factory'lerden birini rastgele seçip GetProduct methodu ile spawn etme işlemini gerçekleştirir.<br><br>

---Triggers---<br>
<b>PocketTrigger.cs =></b> Topların bilardo masasında cebe girdiğini tespit eden sınıftır. Tespit edilen Gameobject PooledObject component'i üzerinden pool'a geri gönderilir.<br>
<b>TableBoundariesTrigger.cs =></b> Topların bilardo masasının sınırları dışına çıktığını tespit eden sınıftır. Tespit edilen Gameobject PooledObject component'i üzerinden pool'a geri gönderilir.

