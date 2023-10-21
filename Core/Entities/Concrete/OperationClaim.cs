namespace Core.Entities.Concrete
{
    /*OperationClaim sınıfı, kimlik doğrulama ve yetkilendirme 
     * sistemleri ile ilgili işlevleri desteklemek üzere kullanılabilir.
     * Kullanıcıların uygulamanın hangi bölümlerine erişebileceğini tanımlamak
     * için kullanılır ve bu sınıf, bu yetkilendirmelerin veritabanında 
     * saklanmasını  kolaylaştırır.*/
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
