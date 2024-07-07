Redis Çalışması
Bu proje, Redis kullanarak in-memory caching, distributed caching, message broker, replication ve sentinel yapıları üzerine öğrendiklerimi içermektedir. Projenin amacı, bu yapıların nasıl çalıştığını anlamak ve çeşitli senaryolarda kullanımlarını incelemektir.

In-Memory Caching
Redis, hızlı ve düşük gecikmeli veri erişimi sağlamak için verileri bellekte tutar. In-memory caching, veri tabanı veya diğer yavaş veri depolarına yapılan isteklerin sayısını azaltarak uygulama performansını artırır. Bu çalışmada, Redis'i bir in-memory cache olarak kullanmanın avantajlarını ve yapılandırma seçeneklerini araştırdım.

Distributed Caching
Büyük ölçekli uygulamalar, birden fazla sunucu arasında yükü dağıtmak için dağıtık önbelleğe ihtiyaç duyar. Redis, clustering ve sharding özellikleri ile dağıtık önbellekleme imkanı sunar. Bu bölümde, Redis'i distributed cache olarak nasıl yapılandırabileceğimi ve veri tutarlılığı ile yük dengeleme konularını inceledim.

Message Broker
Redis, publish/subscribe (pub/sub) modeli ile mesajlaşma hizmeti sunar. Bu model, uygulama bileşenleri arasında asenkron iletişim sağlamak için kullanılır. Redis'in message broker olarak nasıl kullanılacağını ve mesaj iletiminde sağladığı avantajları inceledim.

Replication
Redis, veri kaybını önlemek ve yüksek erişilebilirlik sağlamak için replikasyon özellikleri sunar. Replikasyon, bir ana sunucudan bir veya daha fazla yedek sunucuya veri kopyalayarak gerçekleşir. Bu bölümde, Redis replikasyonunun nasıl çalıştığını ve yapılandırma detaylarını ele aldım.

Sentinel
Redis Sentinel, Redis'in yüksek erişilebilirliğini ve otomatik failover sağlamak için kullanılan bir sistemdir. Sentinel, Redis sunucularını izler ve bir ana sunucu arızalandığında otomatik olarak yeni bir ana sunucu atar. Bu çalışmada, Redis Sentinel'in yapılandırılması ve sağladığı faydalar üzerinde durdum.

