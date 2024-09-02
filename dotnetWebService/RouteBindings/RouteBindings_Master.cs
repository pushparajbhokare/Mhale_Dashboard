using Microsoft.AspNetCore.Http; //to Use Results,IResult Type
using System.Threading.Tasks; 
using System.Net.Http;
using System.Collections.Generic;
using helpers; //for randomGenerators
using XMLObjects;
using JWT;
using BackendStoreManager;//for authKeeper &TokenManager access
using FileHandler;// to access the result file of candidates
using Microsoft.AspNetCore.Mvc; 
using App.Configurations; // to access the configurations
using PartDataManager; // to access the jsonData Stored in BackendDatabase
using RequestResponseHandlers; //to read the body stream;
using System.IO;
//using pdfFileReader; // to access the test pdf file reader;
using Microsoft.AspNetCore.Hosting; // to access the IWebHostEnvironment

namespace App.RouteBindings
{
public static class RouteMethods{
  public static IResult IndexMethod(){
    return Results.LocalRedirect("~/index.html",false,true);
  }
  public static IResult pageRedirect(HttpRequest request){
    return Results.LocalRedirect($"~{request.Path}/index.html",false,true);
  }
  public static IResult pageRedirectWithLineParams(HttpRequest request){
    var param="Line";
    var val = request.Query[$"{param}"];
    return Results.LocalRedirect($"~{request.Path}/index.html?Line={val}",false,true);
  }
  public static IResult pageRedirectWithSerialParams(HttpRequest request){
    var param="serialNum";
    var val = request.Query[$"{param}"];
    return Results.LocalRedirect($"~{request.Path}/index.html?{param}={val}",false,true);
  }

  public static IResult pageRedirectWithParams(HttpRequest request)
        {
            var param = "serialNum";
            var val = request.Query[$"{param}"];
            return Results.LocalRedirect($"~{request.Path}/index.html?{param}={val}", false, true);
        }

  public static IResult MoveToHomeScreen(HttpRequest request){
    return Results.LocalRedirect("~/Home",false,true);
  }

} 
}