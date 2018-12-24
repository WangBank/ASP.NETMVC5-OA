

 

namespace IDAL
{
    public partial interface IDbSession
    {
   
    
	IActionInfoDal ActionInfoDal { get; }

    
	IBooksDal BooksDal { get; }

    
	IDepartmentDal DepartmentDal { get; }

    
	IFileInfoDal FileInfoDal { get; }

    
	IKeyWordsRankDal KeyWordsRankDal { get; }

    
	IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal { get; }

    
	IRoleInfoDal RoleInfoDal { get; }

    
	ISearchDetailsDal SearchDetailsDal { get; }

    
	IUserInfoDal UserInfoDal { get; }

    
	IWF_ItemDal WF_ItemDal { get; }

    
	IWF_StepDal WF_StepDal { get; }

    
	IWF_TempDal WF_TempDal { get; }


}
}
