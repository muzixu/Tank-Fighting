using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksMP
{
    public class MyTestAI : BaseControl
    {
        float chooseTankTime;
        Vector3 birthPoint;
        bool isMark;
        private void Awake()
        {
            isMark = false;
            chooseTankTime = 0;
        }
        protected override void OnUpdate()
        {
            /*
            if (!isMark) birthPoint = tankPlayer.transform.position;
            chooseTankTime += Time.deltaTime;
            if (chooseTankTime > 0.5f)
            {
                chooseTankTime = 0;
                base.OnUpdate();
                float minDistance = 100000f;
                GameObject[] allplayer = GameObject.FindGameObjectsWithTag("Player");
                foreach (var pl in allplayer)
                {
                    var comp = pl.GetComponent<BasePlayer>();
                    if (comp.teamIndex != tankPlayer.teamIndex && comp.IsAlive)
                    {
                        var position = (tankPlayer.transform.position - comp.transform.position).magnitude;
                        Debug.Log("position=" + position);
                        if (position > minDistance) continue;
                        minDistance = position;
                        Debug.Log("TankTeamis "+comp.teamIndex);
                        lockPlayer = comp;
                        
                    }
                }
            }
            //Debug.Log("lockPlayerTeamis " + lockPlayer.teamIndex);

            if (lockPlayer != null)
            {
                tankPlayer.MoveTo(lockPlayer.Position);
                Debug.Log("RemainingDistance: "+tankPlayer.agent.remainingDistance);
                //if (tankPlayer.agent.remainingDistance < 20f) tankPlayer.agent.isStopped = true;
                //else tankPlayer.agent.isStopped = false;
                //if (tankPlayer.agent.remainingDistance < 20f) tankPlayer.MoveTo(birthPoint);
                if (tankPlayer.bShootable)
                {
                  
                    tankPlayer.AimAndShoot(lockPlayer.Position+lockPlayer.transform.forward.normalized*5);
                }
            }

        }
        */




            BasePlayer lockPlayer;
            //GameObject lockPowerUp;

            base.OnUpdate();
            float min = 100000f;
            GameObject[] allCollectible = GameObject.FindGameObjectsWithTag("Powerup");
            var minCollectible = allCollectible[0];
            foreach (var pu in allCollectible)
            {
                Collectible type = pu.GetComponent<Collectible>();
                if (type.type == CollectibleType.PowerupHealth && tankPlayer.health == 10) continue;
                if (type.type == CollectibleType.powerupShield && tankPlayer.shield == 3) continue;
                if ((tankPlayer.Position - pu.transform.position).magnitude < min)
                {
                    min = (tankPlayer.Position - pu.transform.position).magnitude;
                    minCollectible = pu;
                }
            }
            tankPlayer.MoveTo(minCollectible.transform.position);
            tankPlayer.RotateTurret(-tankPlayer.transform.forward.x, -tankPlayer.transform.forward.z);
            if (tankPlayer.bShootable)
            {
                tankPlayer.Shoot();

                //tankPlayer.AimAndShoot(-tankPlayer.transform.forward.normalized);
            }
        }
    }
}
