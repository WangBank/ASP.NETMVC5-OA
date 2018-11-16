 
namespace IDAL
{
    public partial interface IDbSession
    {
   
    
	IActionInfoDal ActionInfoDal { get; }

    
	IBooksDal BooksDal { get; }

    
	IDepartmentDal DepartmentDal { get; }

    
	IKeyWordsRankDal KeyWordsRankDal { get; }

    
	IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal { get; }

    
	IRoleInfoDal RoleInfoDal { get; }

    
	ISearchDetailsDal SearchDetailsDal { get; }

    
	IUserInfoDal UserInfoDal { get; }

}
}
