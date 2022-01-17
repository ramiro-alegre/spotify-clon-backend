# Backend of "Spotify-clon"(watch in my Github)

## Nuget package
1- Microsoft.EntityFrameworkCore 5.0.13 <br>
2- Microsoft.EntityFrameworkCore.SqlServer 5.0.13 <br>
3- Microsoft.EntityFrameworkCore.Tools 5.0.13 <br>
4- Microsoft.VisualStudio.Web.CodeGeneration.Design 5.0.2 <br>
5- Microsoft.AspNetCore.Authentication.JwtBearer 5.0.13 <br>
6- Microsoft.IdentityModel.Tokens 6.15.0 <br>
7- System.IdentityModel.Tokens.Jwt 6.15.5 <br>
8- Swashbuckle.AspNetCore 5.6.3 (for Swagger documentation) 

## Warning

This API use JWT, and is documentated with swagger. If u need use a Http method, the Api need a JWT 

## Data example 

### Data for "Track"
{ <br>
  "id": 0, <br>
  "name": "Me estas tentando", <br>
  "album": "Me estas tentando", <br>
  "cover": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ9o_E4nq6SmI0U8Rfv0IV1t_eaTmBLbqnGzg&usqp=CAU", <br>
  "artist": { <br>
    "id": 0, <br> 
    "name": "Wisin & Yandel", <br>
    "nickname": "Wisin & Yandel", <br> 
    "nationality": "PR" <br>
  }, <br>
  "duration": { <br> 
    "id": 0, <br>
    "start": 0, <br>
    "end": 333 <br>
  }, <br> 
  "url": "../assets/songs/track-8.mp3" <br>
}<br>
 
