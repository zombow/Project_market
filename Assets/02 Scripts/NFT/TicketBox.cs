using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TicketBox : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetBearerToken());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetBearerToken()
    {
        UnityWebRequest request;
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("grant_type", "client_credentials");
        data.Add("client_id", "Testaccount-capsule");
        data.Add("client_secret", "82c19251-1753-44f5-ae76-93438d3628de");
        using (request = UnityWebRequest.Post("https://login-staging.arkane.network/auth/realms/Arkane/protocol/openid-connect/token",
            data)) 
        {
            yield return request.SendWebRequest();
            if (request.responseCode == 200)
            {
                print(request.downloadHandler.text);
            }
        }
    }
}
