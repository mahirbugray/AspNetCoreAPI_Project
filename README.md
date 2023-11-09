
# JWT Bearer API Project
TR -> Asp.Net Core 7 teknolojisi ve MVC mimarisi ile yazılmış JWT token doğrulama sistemini kullanan bir API projesi geliştirdim. Bu projede önce kayıt ve giriş işlemi yapıp yetkiye göre veri çekme işlemi gerçekleştiriliyor. Bu işlem JWT Bearer yetkilendirme sistemi ile yapılmıştır. Kayıt olup giriş yaptıktan sonra giriş yapan kullanıcıya bir token verilir bu token sunucunun hafızasında tutulmaktadır. Kullanıcı giriş yaptığında bu token api tarafından kontrol edilir ve eğer doğrulama başarılı ise kullanıcı verileri çekebilir. Token süresi sona erdiği taktirde yeni bir token üretmemiz gerekmektedir.

ENG -> I developed an API project using JWT token validation system written with Asp.Net Core 7 technology and MVC architecture. In this project, first registration and login process is performed and data extraction is performed according to authorization. This process was done with the JWT Bearer authorization system. After registering and logging in, a token is given to the logged in user and this token is stored in the server's memory. When the user logs in, this token is checked by the API and if the verification is successful, the user can withdraw the data. If the token expires, we need to generate a new token.
## Kullanılan Teknolojiler / Used Technologies

- Katmanlı Mimari / Onion Pattern
- Json Web Token Authentication (JWT)
- Asp.Net Core 7
- Identity Authorization
- Entity Framework Core
- MS Sql
- Generic Repository
- Unit Of Work
- LINQ
## Usage/Examples
``` javascript
{
  "ConnectionStrings": {
    "ConnStr": "Bu kısmı kendinize göre ayarlamanız gereklidir"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```

## API Reference

#### Kayıt Ol

```http
    POST api/Account/Register
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Id` | `string` | Id |
| `FirstName` | `string` |FirstName |
| `LastName` | `string` | LastName |
| `UserName` | `string` | UserName |
| `Phone` | `string` | Phone |
| `Email` | `string` | Email |
| `Password` | `string` | Password |
| `ConfirmPassword` | `string` | ConfirmPassword |

#### Giriş / Login

```http
    POST api/Employee
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `UserName` | `string` | UserName |
| `Password` | `string` | Password |


#### Hepsini Getir / GetAll

```http
      GET api/Employee
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Id` | `string` | Id |
| `FirstName` | `string` |FirstName |
| `LastName` | `string` | LastName |
| `Phone` | `string` | Phone |
| `Email` | `string` | Email |


#### Id Parametresine Göre Getir / GetById

```http
        GET /api/Employee/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Id` | `string` |Boş bırakılamaz bu parametreye göre işlem yapıyoruz. |


 
