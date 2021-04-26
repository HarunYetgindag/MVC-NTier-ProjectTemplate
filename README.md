# MVC-NTier-ProjectTemplate

>  Örnek bir projeden bir başka proje için alt yapı olarak kullanılması amacıyla sadeleştirilmiştir. Kullanılan temeller -> 

- Data Annotations, Exception Filter, Auth Filter, Generic Repository, Singleton (context), Code First gibi teknolojiler ve yöntemler kullanılmıştır. Örnek olması için hazır olarak 
Login ve Register hazır olarak gelmektedir.

- Yapılması gereken Entities katmanında db tarafında oluşması istenen tablo ve alanların yazılması daha sonrasında Data Access katmanı seçilerek Migration aktif edilip update-database
komutu ile db nin oluşması sağlanmalı. 

- Db oluşma sırasında eklenmesi istenen veriler veya yapılması istenen farklı işlemler var ise CustomInitialize classında istenen işlemler yapılabilir.  Data Annotations yerine Fluent Api entegre edebilirsiniz.

- Db işlemleri için Business Layer'da Manager classları yazılmalı ve controller tarafında kullanılmalı.
