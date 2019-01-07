# OA
ASP.NET MVC5 Spring.Net

VS2015编写，目前已经完成工作如下

整体框架分：Model，BLL，DAL，Common，UI，IBLL，IDAL，DALFactory

IOC框架使用Spring.Net

ORM框架使用EF6 

记录缓存是Memcached+cookies代替session，

注：测试的话跟据ef生成sql语句，调整相应的OAEntities1，修改对应的数据库地址和用户名等等

2018/11/21：使用ligerui页面布局，完成home/index页面


添加用户管理页面
  用户增删改查
  
添加权限管理页面
  权限增删改查
  
添加角色管理页面
  角色增加
  
用户设置角色功能

权限设置角色功能

2018/12/07根据分配的权限角决定用户是否可以加载某些菜单项，完成

2018/12/24 工作流模板明细及添加
