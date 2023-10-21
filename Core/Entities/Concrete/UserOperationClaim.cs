namespace Core.Entities.Concrete
{
    /*UserOperationClaim sınıfı, kimlik doğrulama ve yetkilendirme 
     * sistemlerinin bir parçası olarak, kullanıcıların işlem
     * yetkilendirmelerini yönetmek ve denetlemek için kullanılır.
     * Bu sınıf, kullanıcıların yetkilendirmelerini ilişkilendirmek 
     * ve saklamak için kullanılan bir araçtır.*/
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
