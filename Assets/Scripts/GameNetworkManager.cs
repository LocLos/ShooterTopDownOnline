using Mirror;
using UnityEngine;

namespace ShooterTopDown
{
    public class GameNetworkManager : NetworkManager
    {
        [SerializeField] private Transform leftPos, rightPos;

        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            GameObject player = numPlayers == 1
                ? Instantiate(playerPrefab, leftPos.position, leftPos.rotation)
                : Instantiate(playerPrefab, rightPos.position, rightPos.rotation);


            player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
            NetworkServer.AddPlayerForConnection(conn, player);
        }
    }
}