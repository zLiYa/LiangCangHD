using Furion.DatabaseAccessor.Extensions;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.JsonSerialization;
using Microsoft.AspNetCore.Mvc;
using HD;
using SqlSugar;
/// <summary>
/// 博客
/// </summary>
[ApiDescriptionSettings("博客相关接口")]
public class UserInfoController : IDynamicApiController
{
    /// <summary>
    /// 用户数据服务
    /// </summary>
    public readonly IRepository<UserInfo> _UserInfoController;
    /// <summary>
    /// json转换
    /// </summary>
    private readonly IJsonSerializerProvider _jsonSerializer;
    /// <summary>
    /// 依赖注入
    /// </summary>
    public UserInfoController(IRepository<UserInfo> UserInfoController, IJsonSerializerProvider jsonSerializer)
    {
        this._UserInfoController = UserInfoController;
        this._jsonSerializer = jsonSerializer;
    }

    /// <summary>
    /// sql操作
    /// </summary>
    /// <returns></returns>
    public string GetSqlUserInfo()
    {
        var dataTable = "select * from UserInfo".SqlQuery<UserInfo>();
        return _jsonSerializer.Serialize(dataTable);
    }

}