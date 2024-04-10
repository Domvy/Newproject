### 3D로 만든 타워디펜스 형식의 게임입니다.
---
#### 게임 스크린샷  
> ![스크린샷 2024-04-11 022755](https://github.com/Domvy/Tower-Defense/assets/90752171/89105dad-507c-4d70-af67-2a2e1f02be83)
> ![스크린샷 2024-04-11 022913](https://github.com/Domvy/Tower-Defense/assets/90752171/9598d953-f134-44c4-8322-547be58e91c4)
---
#### 사용한 스크립트 내용  
* 타워 생성
  
  ![bandicam 2024-04-11 02-49-24-105](https://github.com/Domvy/Tower-Defense/assets/90752171/f6de3eb6-abc7-4ef1-90e4-921b9e3351e2)
  
  [TowerCreate.cs](Assets/Script/GameSetting/TowerCreate.cs)  
  ```  
  public void NormalTowerCreate() // 타워 생성 설정
  {
    ray = Camera.main.ScreenPointToRay(Input.mousePosition); //레이캐스트 설정   
    turretPoint = LayerMask.GetMask("TurretPoint");
    ground = LayerMask.GetMask("Ground");
    if (Input.GetMouseButtonDown(0))
    {
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, turretPoint) && EventSystem.current.IsPointerOverGameObject())
        {
            BasicSetting.instance.PlayerMoney -= 10;
            if (BasicSetting.instance.PlayerMoney < 0)
            {
                Debug.Log("골드 부족");
                BasicSetting.instance.PlayerMoney += 10;
                notice.SetActive(true);
                text.text = "골드가 부족합니다";
            }
            else
                Instantiate(normaltower, hit.transform.position, Quaternion.identity);
        }
        else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground) && EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("타워 배치 불가");
            notice.SetActive(true);
            text.text = "타워를 배치할 수 없는 지역입니다.";
        }

    }
  }  
  ```
* 적 생성
  
  ![bandicam 2024-04-11 02-55-40-189](https://github.com/Domvy/Tower-Defense/assets/90752171/f06d1f5f-0b15-453f-996a-1fa385a315de)

  
  [EnemySpawn.cs](Assets/Script/GameSetting/EnemySpawn.cs)
  ```  
    public IEnumerator SpawnEnemy()
  {
    while (enemyCount > 0)
    {
        if(clone != null)
        {
            clone = null;
        }

        if(roundCount >= 2 && totalSpawn % 5 == 0)
        {
            clone = Instantiate(SpeedEnemy, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("SpeedEnemySpawn!");
        }
        else if (roundCount >= 3 && totalSpawn % 11 == 0)
        {
            clone = Instantiate(BigEnemy, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("BigEnemySpawn!");
        }
        else if (roundCount == SlimeBossRound)
        {
            clone = Instantiate(SlimeBoss, spawnPoint.position, spawnPoint.rotation);                
            Debug.Log("BossEnemySpawn!");
            SlimeBossRound = 0;
        }
        else
        {
            clone = Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation); // 적 생성 
        }
        enemyList.Add(clone); // 생성된 값 배열추가
        totalSpawn++;
        yield return new WaitForSeconds(spawnCount);
        enemyCount--; // 총 생성 카운트 감소
        Debug.Log("EnemySpawn!");            
    }
  }  
  ```
* 타워 인공지능
  
  ![bandicam 2024-04-11 02-57-40-996](https://github.com/Domvy/Tower-Defense/assets/90752171/c408420b-cbdb-4fcb-840b-9d7ddf98345c)
  
  [TowerAi.cs](Assets/Script/TowerSetting/TowerAi.cs)  
  [AttackScript.cs](Assets/Script/TowerSetting/NormalAttackScript.cs)  
  ```
  rangeUpCount = GameObject.Find("Controller").GetComponent<UpgradeScript>().RangeUpCount;
  towerRangeX = 20 + (10 * rangeUpCount);
  timer += Time.deltaTime;
  enemySpawnList = GameObject.Find("Controller").GetComponent<EnemySpawn>().enemyList; // 적 생성 배열값 받아옴
  if(target == null)
  {
    Targeting();
  }
  else if (target != null)
  {
    transform.LookAt(target.transform);
    if (timer > waitingtime) // 공격 딜레이 생성
    {                
        NormalAttack();
        timer = 0f;
    }
  }  
  ```
