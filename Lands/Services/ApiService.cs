namespace Lands.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
   using System.Web.Services.Protocols;
    using System.Xml.Linq;
    using Domain;
    using Helpers;
    using Models;
    using Newtonsoft.Json;
    using Plugin.Connectivity;
   using System.Linq;
   using Lands.SOAP;


  
    public class ApiService
    {
        public async Task<Response>CogeAlumnos<T>(
         string urlBase,
         string tokenfam,
         string centrofam,
         string idfam)
        {
            try
            {
                //  var url = "https://comocomen.com/main_control/servidor_ws.php";
                var action = "infoFamiliar";
                var soapAction = "https://comocomen.com/main_control/servidor_ws.php";
                var parms = new Dictionary<string, string>();

                parms.Add("token", tokenfam);
                parms.Add("centro", centrofam);
                parms.Add("idfam",idfam);

                string result = SOAPHelper.SendSOAPRequest(urlBase,
                                action,
                                parms,
                                soapAction,
                                false);
                var soap = XDocument.Parse(result);
                XNamespace ns1 = "https://comocomen.com/";
       

                string miresul = (string)
               (from el in soap.Descendants(ns1 + "infoFamiliarResponse") select el).First();

                //       MainViewModel.GetInstance().Familia = new FamiliaViewModel(result);
                var resul = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(miresul);
              
                return new Response
                {
                    IsSuccess = true,
                    Result = resul,
                };

            }
            catch
            {
                return new Response
                {
                    IsSuccess = false,
                };

            }
        }

        public async Task<Response> CogeAccesos<T>(
       string urlBase, 
       string tokenfam,
       string centrofam,
       string nexp,
       string f1,
       string f2,
       string servicio)
       
        {
            try
            {
                //  var url = "https://comocomen.com/main_control/servidor_ws.php";
                var action = "infoServicioAccesos";
                var soapAction = "https://comocomen.com/main_control/servidor_ws.php";
                var parms = new Dictionary<string, string>();

                parms.Add("token", tokenfam);
                parms.Add("centro", centrofam);
                parms.Add("nexp", nexp);
                parms.Add("f1", f1);
                parms.Add("f2", f2);
                parms.Add("servicio", servicio);
               
                string result = SOAPHelper.SendSOAPRequest(urlBase,
                                action,
                                parms,
                                soapAction,
                                false);
                var soap = XDocument.Parse(result);
                XNamespace ns1 = "https://comocomen.com/";


                string miresul = (string)
               (from el in soap.Descendants(ns1 + "infoServicioAccesosResponse") select el).First();

                //       MainViewModel.GetInstance().Familia = new FamiliaViewModel(result);
                var resul = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(miresul);

                if (resul.Count == 0)
                {
                     miresul = "[{'fechora_comidas':'2001-03-04 12:00','ser_comidas':'01','tipo_comidas':'A'}]";
                     resul = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(miresul);


                    return new Response
                   {
                        
                    IsSuccess = true,

                    Result = resul,

                       };
                }
                else
                {
                    return new Response
                    {

                        IsSuccess = true,

                        Result = resul,

                    };


                }


            }
            catch
            {
                return new Response
                {
                    IsSuccess = false,
                };

            }
        }


        public async Task<Response> CogeServiciosMes<T>(
    string urlBase,
    string tokenfam,
    string centrofam,
    string nexp,
    string f1,
    string servicio)

        {
            try
            {
                //  var url = "https://comocomen.com/main_control/servidor_ws.php";
                var action = "infoCalendarioServicios";
                var soapAction = "https://comocomen.com/main_control/servidor_ws.php";
                var parms = new Dictionary<string, string>();

                parms.Add("token", tokenfam);
                parms.Add("centro", centrofam);
                parms.Add("nexp", nexp);
                parms.Add("fecha", f1);
                parms.Add("servicio", servicio);

                string result = SOAPHelper.SendSOAPRequest(urlBase,
                                action,
                                parms,
                                soapAction,
                                false);
                var soap = XDocument.Parse(result);
                XNamespace ns1 = "https://comocomen.com/";


                string miresul = (string)
               (from el in soap.Descendants(ns1 + "infoCalendarioServiciosResponse") select el).First();

                //       MainViewModel.GetInstance().Familia = new FamiliaViewModel(result);
                var resul = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(miresul);

                if (resul.Count == 0)
                {
                    miresul = "[{'fecha':'2001-03-04','servicio':'1'}]";
                    resul = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(miresul);


                    return new Response
                    {

                        IsSuccess = true,

                        Result = resul,

                    };
                }
                else
                {
                    return new Response
                    {

                        IsSuccess = true,

                        Result = resul,

                    };


                }


            }
            catch
            {
                return new Response
                {
                    IsSuccess = false,
                };

            }
        }

        public async Task<Response> CogeAvisos<T>(
string urlBase,
string tokenfam,
string centrofam,
string fam)



        {
            try
            {
                //  var url = "https://comocomen.com/main_control/servidor_ws.php";
                var action = "infoMensajeria";
                var soapAction = "https://comocomen.com/main_control/servidor_ws.php";
                var parms = new Dictionary<string, string>();

                parms.Add("token", tokenfam);
                parms.Add("centro", centrofam);
                parms.Add("idfam", fam);


                string result = SOAPHelper.SendSOAPRequest(urlBase,
                                action,
                                parms,
                                soapAction,
                                false);
                var soap = XDocument.Parse(result);
                XNamespace ns1 = "https://comocomen.com/";


                string miresul = (string)
               (from el in soap.Descendants(ns1 + "infoMensajeriaResponse") select el).First();

                //       MainViewModel.GetInstance().Familia = new FamiliaViewModel(result);
                var resul = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(miresul);

                return new Response
                {
                    IsSuccess = true,
                    Result = resul,
                };

            }
            catch
            {
                var miresul = "[{'fecha':'2001-03-04','textoAviso':'Sin Avisos','alumnos':'ERROR' ,'nexp':'1' } ]";
                var resul = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(miresul);



                return new Response
                {

                    IsSuccess = true,
                    Result = resul,
                  
                };

            }
        }




        public async Task<Response>CogeAvisos2<T>(
       string urlBase,
       string username,
       string password)
        {
            try
            {
                // desmaracr cuanto tengamos el servicio   
                //      var action = "infoAvisos";
                //     var soapAction = "https://comocomen.com/main_control/servidor_ws.php";
                //     var parms = new Dictionary<string, string>();

                //     parms.Add("token", "89qtbiau5hyc1xd2voe7rgs68mpak643wl2fb8j5bzd00nb3a");
                //    parms.Add("centro", "beta");
                //   parms.Add("idfam", "1");

                //   string result = SOAPHelper.SendSOAPRequest(urlBase,
                //                   action,
                //                   parms,
                //                   soapAction,
                //                  false);
                //  var soap = XDocument.Parse(result);
                //        XNamespace ns1 = "https://comocomen.com/";


                //     string miresul = (string)
                //    (from el in soap.Descendants(ns1 + "infoFamiliarResponse") select el).First();

                //       MainViewModel.GetInstance().Familia = new FamiliaViewModel(result);
                var miresul = "[{'fecha':'2018-04-04','texto':'El alumno ha comido todo','destinatarios':[{'expediente':'23','nombre':'Pedro Lopex Lopex'}],'autor':'EL MONITOR DEL COMEDOR' ,'tipo':'aviso'},{'fecha':'2018-04-05','texto':'El alumno ha asistido','destinatarios':[{'expediente':'23','nombre':'Pedro Lopex Lopex'},{'expediente':'1','nombre':'Julio Lopex Lopex'}],'autor':'EL MONITOR DEL judo' ,'tipo':'aviso'}]";
                var resul = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(miresul);
               
                var ss = miresul;
                return new Response
                {
                    IsSuccess = true,
                    Result = resul,
                };

            }
            catch
            {
                return new Response
                {
                    IsSuccess = false,
                };

            }
        }
   

        public async Task<Response> CogeServicios<T>(
   string urlBase,
   string username,
   string password)
        {
            try
            {
                // desmaracr cuanto tengamos el servicio   
                //      var action = "infoServicio";
                //     var soapAction = "https://comocomen.com/main_control/servidor_ws.php";
                //     var parms = new Dictionary<string, string>();

                //     parms.Add("token", "89qtbiau5hyc1xd2voe7rgs68mpak643wl2fb8j5bzd00nb3a");
                //    parms.Add("centro", "beta");
                //   parms.Add("idfam", "1");

                //   string result = SOAPHelper.SendSOAPRequest(urlBase,
                //                   action,
                //                   parms,
                //                   soapAction,
                //                  false);
                //  var soap = XDocument.Parse(result);
                //        XNamespace ns1 = "https://comocomen.com/";


                //     string miresul = (string)
                //    (from el in soap.Descendants(ns1 + "infoFamiliarResponse") select el).First();

                //       MainViewModel.GetInstance().Familia = new FamiliaViewModel(result);
                var miresul = "[{'codservicio':'1','tipoasistencia':'01','nombreasistencia':'Esporadico','diasasistencia':'juevesviernes','numeroasistencias':'14','codmesa':'01','codturno':'01','nombreservicio':'Desayuno','nombreturno':'1º turno','nombretipoacceso':'no se sabe'},{'codservicio':'2','tipoasistencia':'01','nombreasistencia':'Diario','diasasistencia':'juevesviernes','numeroasistencias':'20','codmesa':'01','codturno':'01','nombreservicio':'Comida','nombreturno':'1º turno','nombretipoacceso':'no se sabe'},{'codservicio':'1','tipoasistencia':'01','nombreasistencia':'Esporadico','diasasistencia':'juevesviernes','numeroasistencias':'14','codmesa':'01','codturno':'01','nombreservicio':'Cena','nombreturno':'1º turno','nombretipoacceso':'no se sabe'}]";
                var resul = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(miresul);

            
                    
                return new Response
                {
                    IsSuccess = true,
                    Result = resul,
                };

            }
            catch
            {
                return new Response
                {
                    IsSuccess = false,
                };

            }
        }

 
        public async Task<Response> CogeMenusesMes<T>(
    string urlBase,
    string tokenfam,
    string centrofam,
    string nexp,
    string fam,
    string f1,
    string f2,
    string servicio)

        {
            try
            {
                //  var url = "https://comocomen.com/main_control/servidor_ws.php";
                var action = "infoMenu";
                var soapAction = "https://comocomen.com/main_control/servidor_ws.php";
                var parms = new Dictionary<string, string>();

                parms.Add("token", tokenfam);
                parms.Add("centro", centrofam);
                parms.Add("f1", f1);
                parms.Add("f2", f2);
                parms.Add("servicio", servicio);
                parms.Add("fam", fam);
               

                string result = SOAPHelper.SendSOAPRequest(urlBase,
                                action,
                                parms,
                                soapAction,
                                false);
                var soap = XDocument.Parse(result);
                XNamespace ns1 = "https://comocomen.com/";


                string miresul = (string)
               (from el in soap.Descendants(ns1 + "infoMenuResponse") select el).First();

                //       MainViewModel.GetInstance().Familia = new FamiliaViewModel(result);
                var resul = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(miresul);

                return new Response
                {
                    IsSuccess = true,
                    Result = resul,
                };

            }
            catch
            {
               

                return new Response
                {
                    IsSuccess = false,
                  

                    
                };

            }
        }



        public async Task<Response> CogeActividades<T>(
      string urlBase,
      string tokenfam,
      string centrofam,
      string nexp,
      string f1)


        {
            try
            {
                //  var url = "https://comocomen.com/main_control/servidor_ws.php";
                var action = "infoActividades";
                var soapAction = "https://comocomen.com/main_control/servidor_ws.php";
                var parms = new Dictionary<string, string>();

                parms.Add("token", tokenfam);
                parms.Add("centro", centrofam);
                parms.Add("f1", f1);
                parms.Add("nexp", nexp);
             

                string result = SOAPHelper.SendSOAPRequest(urlBase,
                                action,
                                parms,
                                soapAction,
                                false);
                var soap = XDocument.Parse(result);
                XNamespace ns1 = "https://comocomen.com/";


                string miresul = (string)
               (from el in soap.Descendants(ns1 + "infoActividadesResponse") select el).First();

                //       MainViewModel.GetInstance().Familia = new FamiliaViewModel(result);
                var resul = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(miresul);

              


                return new Response
                {
                    IsSuccess = true,
                    Result = resul,
                };

            }
            catch
            {
                var miresul = "[{\"cod_act\":\"5\",\"nom_act\":\"Yoga moderno\",\"dias_semana\":\" L X J V D \",\"lun_hdes_act\":\"10:00:00\",\"lun_hhas_act\":\"11:00:00\",\"mar_hdes_act\":\"00:00:00\",\"mar_hhas_act\":\"00:00:00\",\"mie_hdes_act\":\"10:00:00\",\"mie_hhas_act\":\"11:00:00\",\"jue_hdes_act\":\"10:00:00\",\"jue_hhas_act\":\"11:00:00\",\"vie_hdes_act\":\"10:00:00\",\"vie_hhas_act\":\"11:00:00\",\"sab_hdes_act\":\"00:00:00\",\"sab_hhas_act\":\"00:00:00\",\"dom_hdes_act\":\"10:00:00\",\"dom_hhas_act\":\"11:00:00\"}]";
                var kk = "kk";
                var resul = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(miresul);
             
                kk = "kk";
                return new Response
                {
                    IsSuccess = true,
                    Result = resul,
            
                };

            }
        }






























        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Languages.ConnectionError1,
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
                "google.com");
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Languages.ConnectionError2,
                };
            }

            return new Response
            {
                IsSuccess = true,
            };
        }

      //  public async Task<Models.FacebookResponse> GetFacebook(string accessToken)
      //  {
      //      var requestUrl = "https://graph.facebook.com/v2.8/me/?fields=name," +
       //         "picture.width(999),cover,age_range,devices,email,gender," +
       //         "is_verified,birthday,languages,work,website,religion," +
        //        "location,locale,link,first_name,last_name," +
        //        "hometown&access_token=" + accessToken;
        //    var httpClient = new HttpClient();
        //    var userJson = await httpClient.GetStringAsync(requestUrl);
        //    var facebookResponse = 
        //        JsonConvert.DeserializeObject<Models.FacebookResponse>(userJson);
        //    return facebookResponse;
   //     }

    //    public async Task<TokenResponse> LoginFacebook(
   //         string urlBase,
    //        string servicePrefix,
    //        string controller,
     //       Models.FacebookResponse profile)
     //   {
     //       try
     //       {
      //          var request = JsonConvert.SerializeObject(profile);
       //         var content = new StringContent(
        //            request,
         //           Encoding.UTF8,
          //          "application/json");
         //       var client = new HttpClient();
          //      client.BaseAddress = new Uri(urlBase);
           //     var url = string.Format("{0}{1}", servicePrefix, controller);
            //    var response = await client.PostAsync(url, content);

//                if (!response.IsSuccessStatusCode)
  //              {
    //                return null;
     //           }

       //         var tokenResponse = await GetToken(
         //           urlBase,
          //          profile.Id,
           //         profile.Id);
            //    return tokenResponse;
          //  }
          //  catch
          ///  {
           //     return null;
          //  }
      //  }

        public async Task<TokenResponse> GetToken(
            string urlBase,
            string username,
            string password)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("Token",
                    new StringContent(string.Format(
                    "grant_type=password&username={0}&password={1}",
                    username, password),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TokenResponse>(
                    resultJSON);
                return result;
            }
            catch
            {
                return null;
            }
        }
        public async Task<LoginResponse> GetLogin(
          string urlBase,
          string username,
          string password,
         string centro)
        {
            try
            {
                var action = "login";
                var soapAction = "https://comocomen.com/main_control/servidor_ws.php";
                var parms = new Dictionary<string, string>();

                parms.Add("user", username);
                parms.Add("pass", password);
                parms.Add("centro", centro);

                string result = SOAPHelper.SendSOAPRequest(urlBase,
                                action,
                                parms,
                                soapAction,
                                false);

                var soap = XDocument.Parse(result);
                XNamespace ns1 = "https://comocomen.com/";


                string miresul = (string)
               (from el in soap.Descendants(ns1 + "loginResponse") select el).First();

                //       MainViewModel.GetInstance().Familia = new FamiliaViewModel(result);
                var resul = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(miresul);
                return resul;
               
            }
              catch
            {
                return new LoginResponse
                               {
                    AccessToken = null,
                };

            }
            }

        public async Task<string> Avisarsistencia(
        string urlBase,
        string token,
        string centro,
        string idfam,
        string nexp,
        string fecha,
        string servicio,
       string tipo)
        {
            try
            {
                var action = "addAvisos";
                var soapAction = "https://comocomen.com/main_control/servidor_ws.php";
                var parms = new Dictionary<string, string>();

                parms.Add("token", token);
                parms.Add("centro", centro);
                parms.Add("idfam", idfam);
                parms.Add("nexp", nexp);
                parms.Add("fecha", fecha);
                parms.Add("servicio", servicio);
                parms.Add("tipo", tipo);


                string result = SOAPHelper.SendSOAPRequest(urlBase,
                                action,
                                parms,
                                soapAction,
                                false);

                var soap = XDocument.Parse(result);
                XNamespace ns1 = "https://comocomen.com/";


                string miresul = (string)
               (from el in soap.Descendants(ns1 + "addAvisosResponse") select el).First();



                //   var resul = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(miresul);
                return miresul;

            }
            catch
            {
                return "No se ha podido procesar la petición";
                {



                }
            }

        }


        public async Task<Response> ChangePassword(
            string urlBase, 
            string servicePrefix, 
            string controller,
            string tokenType, 
            string accessToken)
        {
            try
            {
        //        var request = JsonConvert.SerializeObject();
      //          var content = new StringContent(request, Encoding.UTF8, "application/json");
        //        var client = new HttpClient();
          //      client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
           //     client.BaseAddress = new Uri(urlBase);
           //     var url = string.Format("{0}{1}", servicePrefix, controller);
            //    var response = await client.PostAsync(url, content);

              //  if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                    };
                }

                return new Response
                {
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> Get<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            int id)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format(
                    "{0}{1}/{2}",
                    servicePrefix,
                    controller,
                    id);
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.StatusCode.ToString(),
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = model,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> GetList<T>(
            string urlBase,
            string servicePrefix,
            string controller)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> GetList<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> GetList<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            int id)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format(
                    "{0}{1}/{2}",
                    servicePrefix,
                    controller,
                    id);
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.StatusCode.ToString(),
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> Post<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(
                    request, Encoding.UTF8,
                    "application/json");
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var error = JsonConvert.DeserializeObject<Response>(result);
                    error.IsSuccess = false;
                    return error;
                }

                var newRecord = JsonConvert.DeserializeObject<T>(result);

                return new Response
                {
                    IsSuccess = true,
                    Message = "Record added OK",
                    Result = newRecord,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> Post<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(
                    request,
                    Encoding.UTF8,
                    "application/json");
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.StatusCode.ToString(),
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var newRecord = JsonConvert.DeserializeObject<T>(result);

                return new Response
                {
                    IsSuccess = true,
                    Message = "Record added OK",
                    Result = newRecord,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<User> GetUserByEmail(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            string email)
        {
            try
            {
                var model = new UserRequest
                {
                    Email = email,
                };

                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(
                    request,
                    Encoding.UTF8,
                    "application/json");
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(result);
            }
            catch
            {
                return null;
            }
        }

        public async Task<Response> Put<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(
                    request,
                    Encoding.UTF8, "application/json");
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format(
                    "{0}{1}/{2}",
                    servicePrefix,
                    controller,
                    model.GetHashCode());
                var response = await client.PutAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var error = JsonConvert.DeserializeObject<Response>(result);
                    error.IsSuccess = false;
                    return error;
                }

                var newRecord = JsonConvert.DeserializeObject<T>(result);

                return new Response
                {
                    IsSuccess = true,
                    Result = newRecord,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> Delete<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            T model)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(tokenType, accessToken);
                var url = string.Format(
                    "{0}{1}/{2}",
                    servicePrefix,
                    controller,
                    model.GetHashCode());
                var response = await client.DeleteAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var error = JsonConvert.DeserializeObject<Response>(result);
                    error.IsSuccess = false;
                    return error;
                }

                return new Response
                {
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}