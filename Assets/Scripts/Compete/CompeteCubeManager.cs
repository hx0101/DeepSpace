using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompeteCubeManager : MonoBehaviour
{
    public GameObject whiteCube;
    public GameObject redCube;
    public GameObject blueCube;
    public GameObject goldenCube;

    GameObject lastSecondCube;
    GameObject lastCube;

    public List<Transform> CubeTransform = new List<Transform>();

    int[] xOrZ = new int[2] { 0, 3 };

    GameObject player;

    void Awake()
    {

    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        lastCube = GameObject.FindWithTag("LastCube");
        lastSecondCube = GameObject.Find("LastSecondCube");
    }

    public void CheckPlayerOnLastCube()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        if (player.transform.position == (lastSecondCube.transform.position + new Vector3(0, player.transform.position.y, 0))
            && CubeTransform.Count < 99)
        {
            AudioManager.TrueAudio();
            AddWhiteCube();
        }
        else if (player.transform.position == (lastSecondCube.transform.position + new Vector3(0, player.transform.position.y, 0))
            && CubeTransform.Count >= 99)
        {
            AudioManager.TrueAudio();
            AddGlodenCube();
        }
        else
        {
            Vector3 vector3 = new Vector3(0, player.transform.position.y, 0);
            int count = 0;
            foreach (var tran in CubeTransform)
            {
                count++;
                if (player.transform.position == (tran.position + vector3))
                {
                    //对话框
                    AudioManager.FalseAudio();
                    break;
                }
                else
                {
                    if (count == CubeTransform.Count)
                    {
                        //游戏结束
                        AudioManager.DefeatAudio();
                        StartScene startScene = new StartScene();
                        SceneControl.GetInstance().LoadScene(startScene.SceneName, startScene);

                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }

    public void AddWhiteCube()
    {
        while (true)
        {
            int xAxis = 0;
            int zAxis = 0;

            int zDirection;

            Vector3 newPosition = lastCube.transform.position;
            if (Random.Range(-1, 1) < 0)
            {
                zDirection = -1;
            }
            else
            {
                zDirection = 1;
            }

            int a;
            if (Random.value >= 0.5)
            {
                a = 1;
            }
            else
            {
                a = 0;
            }

            switch (a)
            {
                case 0:
                    xAxis = xOrZ[0];
                    zAxis = xOrZ[1];
                    break;
                case 1:
                    zAxis = xOrZ[0];
                    xAxis = xOrZ[1];
                    break;
            }

            newPosition += new Vector3(xAxis * zDirection, 0, zAxis);

            int count = 0;
            foreach (var tran in CubeTransform)
            {
                count++;
                if (tran.position == newPosition)
                {
                    break;
                }
                else
                {
                    if (count < CubeTransform.Count)
                    {
                        continue;
                    }
                    else
                    {
                        GameObject cube = Instantiate(whiteCube, newPosition, Quaternion.identity);
                        lastCube.tag = "Cube";
                        lastSecondCube = lastCube;
                        CubeTransform.Add(cube.transform);
                        lastCube = cube;
                        lastCube.tag = "LastCube";
                        return;
                    }
                }
            }
            continue;
        }
    }

    public void AddGlodenCube()
    {
        switch (CubeTransform.Count)
        {
            case 99:
                GameObject goldenCube1 = Instantiate(goldenCube, lastCube.transform.position + new Vector3(0, 0, 3), Quaternion.identity);
                lastCube.tag = "Cube";
                CubeTransform.Add(goldenCube1.transform);
                lastCube = goldenCube1;
                lastSecondCube = lastCube;
                lastCube.tag = "LastCube";
                return;
            case 100:
                Debug.Log("成功");
                return;
        }
    }
}
