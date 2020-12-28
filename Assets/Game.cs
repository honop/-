using Sequence = System.Collections.IEnumerator;

/// <summary>
/// ゲームクラス。
/// 学生が編集すべきソースコードです。
/// </summary>
public sealed class Game : GameBase
{
    // 変数の宣言
    const int BALL_NUM = 20; ///ボールの数が20個
    int[] ball_x = new int [BALL_NUM]; //ball_xはint型の配列で要素数がBALL_NUM = 20だけある
    int[] ball_y = new int [BALL_NUM]; //ball_yはint型の配列で要素数がBALL_NUM = 20だけある
    int[] ball_type = new int [BALL_NUM]; //ball_colはint型の配列で要素数がBALL_NUM = 20だけある
    int[] ball_speed = new int [BALL_NUM]; //ball_speedはint型の配列で要素数がBALL_NUM = 20だけある
    int ball_w = 24;
    int ball_h = 24;


    int player_x = 337;
    int player_y = 895;
    int player_speed = 3;
    int player_w = 83;
    int player_h = 150;
    int player_img;

    int score = 0;
    int time = 1800;

    int gameState = 0;


    /// <summary>
    /// 初期化処理
    /// </summary>
    public override void InitGame()
    {
        // キャンバスの大きさを設定します
        gc.SetResolution(720, 1280);
        for(int i =0 ; i < BALL_NUM ; i ++ )
        {
          resetBall(i);
        }
    }


    /// <summary>
    /// 動きなどの更新処理
    /// </summary>
    public override void UpdateGame()
    {   
      gc.PlaySound(0, true);
      if(gameState == 0)
        { 
          //タイトル画面&遊び方の処理
          if (gc.GetPointerX(0) > 210 && gc.GetPointerX(0) <510 && gc.GetPointerY(0) > 1090 && gc.GetPointerY(0) < 1235 && gc.GetIsPointerEnded(0) && gc.GetPointerDuration(0) >= 0.3f)
          { 
            gc.PlaySE(1, false);
            gameState = 1;
          }
        }

        else if(gameState == 1)
        {
          //タイトル画面の処理
          if (gc.GetPointerX(0) > 20 && gc.GetPointerX(0) <350 && gc.GetPointerY(0) > 190 && gc.GetPointerY(0) < 415)
          { gc.PlaySE(3, false);
            gameState = 2; //女の子の学生証を選んだらgameState =2になる
          }
          else if(gc.GetPointerX(0) > 370 && gc.GetPointerX(0) < 700 && gc.GetPointerY(0) > 190 && gc.GetPointerY(0) < 415)
          {
            gc.PlaySE(3, false);
            gameState = 3; //男の子の学生証を選んだらgameState =3にすすむ
          }
        }

        else if(gameState == 2)
        { //プレイヤー確認 女
          if (gc.GetPointerX(0) > 430 && gc.GetPointerX(0) <607 && gc.GetPointerY(0) > 805 && gc.GetPointerY(0) < 870)
          { gc.PlaySE(1, false);
            gameState = 4; //すすむを選んだらgameState =4になる
          }
          else if(gc.GetPointerX(0) > 430 && gc.GetPointerX(0) < 607 && gc.GetPointerY(0) > 955 && gc.GetPointerY(0) < 1020)
          { gc.PlaySE(2, false);
            gameState = 1; //もどるを選んだらgameState =1にもどる
          }
          
        }


        else if(gameState == 3)
        { //プレイヤー確認 男
          if (gc.GetPointerX(0) > 430 && gc.GetPointerX(0) <607 && gc.GetPointerY(0) > 805 && gc.GetPointerY(0) < 870)
          { gc.PlaySE(1, false);
            gameState = 5; //すすむを選んだらgameState =5になる
          }
          else if(gc.GetPointerX(0) > 430 && gc.GetPointerX(0) < 607 && gc.GetPointerY(0) > 955 && gc.GetPointerY(0) < 1020)
          { gc.PlaySE(2, false);
            gameState = 1; //もどるを選んだらgameState =1にもどる
          }
        }

        else if(gameState == 4)
        { //女の子verのゲーム画面
          
          time--; //timeを1減らす

          if(gc.GetPointerFrameCount(0) > 0 )
          { 
            player_img = 30;

            if(gc.GetPointerX(0) > 100 && gc.GetPointerX(0) <250  && gc.GetPointerY(0) > 1150 && gc.GetPointerY(0) < 1220) {
              player_x -= player_speed;
            }
            else if(gc.GetPointerX(0) > 470 && gc.GetPointerX(0) <620 && gc.GetPointerY(0) > 1150 && gc.GetPointerY(0) < 1220)
            {
              player_x += player_speed;  
            }
          }

          for(int i =0; i < BALL_NUM; i ++ )
          { 
            ball_y[i] = ball_y[i] + ball_speed[i]; //ball_y配列のi番目の要素 = ball_y配列のi番目の要素 + ball_speed配列のi番目の要素

            if(ball_y[i]> 1040){
              resetBall(i);
            } //もしball_yのi番目の要素>1040(画面のy座標=1040より上)だったら、resetBallの処理に移る

            if(gc.CheckHitRect(ball_x[i], ball_y[i], ball_w, ball_h, player_x, player_y, player_w, player_h)){ //ballとplayerが接触しているかの判定
              if(time>=0)
              {
                if(ball_type[i] == 32) { //ballのtypeが32(単位)だったら
                  gc.PlaySE(4, false);
                  score += 2;
                }
                else if(ball_type[i] ==33) //ballのtypeが33(回復リンゴ)だったら
                { 
                  gc.PlaySE(4, false);
                  score += 10;
                }
                else if(ball_type[i] ==34) //ballのtypeが34(虹色の鉱石)だったら
                { 
                  gc.PlaySE(4, false);
                  score += 21;
                }
                else if(ball_type[i] ==35) //ballのtypeが35(毒林檎)だったら
                { 
                  gc.PlaySE(5, false);
                  score -= 2;
                }
                else if(ball_type[i] ==36) //ballのtypeが36(毒薬)だったら
                { 
                  gc.PlaySE(5, false);
                  score -= 10;
                }
                else if(ball_type[i] ==37) //ballのtypeが37(退学届)だったら
                { 
                  gc.PlaySE(6, false);
                  time = 0; //即放塾
                }
              }
                resetBall(i); //resetBallの処理に移る
            }
          }

          if(time>=0){
            gameState = 4;
          }
          else
          { 
            gc.PlaySE(6, false);
            player_img = 17;
            gameState = 6;
          }

          if(score >=124)
          { gc.PlaySE(7, false);
            player_img = 30;
            gameState = 7;
          }
          
        }

        else if(gameState == 5)
        { //男の子verプレイ画面

          time--; //timeを1減らす

          if(gc.GetPointerFrameCount(0) > 0 )
          {
            player_img = 31;
            if(gc.GetPointerX(0) > 100 && gc.GetPointerX(0) <250  && gc.GetPointerY(0) > 1150 && gc.GetPointerY(0) < 1220) {
              player_x -= player_speed;
            }
            else if(gc.GetPointerX(0) > 470 && gc.GetPointerX(0) <620 && gc.GetPointerY(0) > 1150 && gc.GetPointerY(0) < 1220)
            {
              player_x += player_speed;
            }
          } //マウスクリックの位置によってプレイヤーが左右に動くようにする

          for(int i =0; i < BALL_NUM; i ++ )
          {
            ball_y[i] = ball_y[i] + ball_speed[i]; //ball_y配列のi番目の要素 = ball_y配列のi番目の要素 + ball_speed配列のi番目の要素
            if(ball_y[i]> 1040){
              resetBall(i);
            } 

            if(gc.CheckHitRect(ball_x[i], ball_y[i], ball_w, ball_h, player_x, player_y, player_w, player_h))
            { //ballとplayerが接触しているかの判定
              if(time>=0)
              {
                if(ball_type[i] == 32) { //ballのtypeが32(単位)だったら
                  gc.PlaySE(4, false);
                  score += 2;
                }
                else if(ball_type[i] ==33) //ballのtypeが33(回復リンゴ)だったら
                { 
                  gc.PlaySE(4, false);
                  score += 10;
                }
                else if(ball_type[i] ==34)
                { 
                  gc.PlaySE(4, false);
                  score += 21;
                }
                else if(ball_type[i] ==35)
                { 
                  gc.PlaySE(5, false);
                  score -= 2;
                }
                else if(ball_type[i] ==36)
                { 
                  gc.PlaySE(5, false);
                  score -= 10;
                }
                else if (ball_type[i] == 37)
                { gc.PlaySE(6, false);
                  time = 0;
                }
              }
                resetBall(i); //resetBallの処理に移る
            }
          }


          if (time>=0){
            gameState = 5;
          }
          else
          { 
            gc.PlaySE(6, false);
            player_img = 18;
            gameState = 6;
          }

          if(score >= 124)
          { gc.PlaySE(7, false);
            player_img = 31;
            gameState = 7;
          }

        }
        else if(gameState == 6)
        { gc.PauseSound(0);
          
          //放塾処理(男女)
          if(gc.GetPointerFrameCount(0) ==1 )
          {
            if(gc.GetPointerX(0) > 258 && gc.GetPointerX(0) <461 && gc.GetPointerY(0) > 1153 && gc.GetPointerY(0) < 1220)
            {
              gameState = 8; //ボタンを押したらgameState = 8にすすむ
            }
          }
        }
        else if (gameState ==7)
        { //卒業おめでとう処理(男女)
          gc.PauseSound(0);

          if(gc.GetPointerFrameCount(0) ==1 )
          {
            if(gc.GetPointerX(0) > 258 && gc.GetPointerX(0) <461 && gc.GetPointerY(0) > 1153 && gc.GetPointerY(0) < 1220)
            { 
              gameState = 9; //ボタンを押したらgameState = 9にすすむ
            }
          }
        }
        else if (gameState ==8)
        {  //放塾end(男女)
          gc.PauseSound(0);
          if(gc.GetPointerFrameCount(0) ==1 )
          { 
            score = 0;
            time = 1800;
            InitGame();

            if(gc.GetPointerX(0) > 283 && gc.GetPointerX(0) <436 && gc.GetPointerY(0) > 1070 && gc.GetPointerY(0) < 1126)
            { 
              gc.PlaySE(3, false);
              gameState = 0; //TOPボタンを押したらgameState =0にもどる
            }
          }
        }
        else if (gameState ==9)
        {  //卒業おめでとうend(男女)
          gc.PauseSound(0);
          if(gc.GetPointerFrameCount(0) ==1 )
          { 
            score = 0;
            time = 1800;
            InitGame();
            if(gc.GetPointerX(0) > 283 && gc.GetPointerX(0) <436 && gc.GetPointerY(0) > 1070 && gc.GetPointerY(0) < 1126)
            { 
              gc.PlaySE(3, false);
              gameState = 0; //TOPボタンを押したらgameState =0にもどる
            }
            }
          }
        
    }
    



    /// <summary>
    /// 描画の処理
    /// </summary>
    public override void DrawGame()
    {
      gc.ClearScreen();

      if(gameState == 0)
      {
        //タイトル画面の処理
        gc.DrawImage(24, 5, 90);
        gc.SetFontSize(60);
        gc.SetColor(91, 194, 54); //green
        gc.DrawCenterString("単位かき集めゲーム", 360, 50);
        gc.SetColor(0, 0, 0); //black
        gc.SetFontSize(25);
        gc.DrawString("単位欲しい！", 290, 370);
        gc.DrawImage(1, 20, 240);
        gc.DrawImage(2, 400, 240);

        gc.DrawImage(23, 0, 630);

        gc.DrawImage(25, 259, 700);
        gc.SetFontSize(36);
        gc.DrawCenterString("遊び方", 360, 700);
        gc.SetFontSize(23);
        gc.DrawString("★時間制限内に空から降ってくる単位を拾い集めて卒業を目指そう！", 0, 790);
        gc.DrawString("★画面タッチでアバターを左右に動かそう！", 0, 835);
        gc.DrawImage(5, 463, 815);
        gc.DrawImage(4, 503, 815);
        gc.DrawString("★「林檎」や「虹色の鉱石」を拾うと単位数が大幅UPするよ！", 0, 880);
        gc.DrawImage(9, 653, 880);
        gc.DrawImage(10, 683, 880);
        gc.DrawString("★「髑髏マーク付きアイテム」を拾うと単位数が減少するよ！", 0, 925);
        gc.DrawImage(11, 653, 925);
        gc.DrawImage(12, 683, 924);
        gc.DrawString("★「退学届」には注意しよう！即放塾になるよ！", 0, 970);
        gc.DrawImage(13, 509, 968);

        gc.DrawImage(23, 0, 1040);

        gc.SetFontSize(20);
        gc.DrawCenterString("長押しでSTART！", 360, 1070);
        gc.DrawImage(14, 210, 1090 ); //スタートボタン
      }
    
      else if(gameState == 1)
      { //プレイヤー選択画面
        gc.SetFontSize(40);
        gc.DrawCenterString("プレイヤーを選択してね！", 360, 80);
        gc.DrawImage(6, 20, 190);
        gc.DrawImage(7, 370, 190);

        gc.DrawImage(23, 0, 505);

        gc.DrawImage(23, 0, 1180);
      }
      else if(gameState == 2)
      { //女の子確認
        gc.SetFontSize(40);
        gc.DrawCenterString("プレイヤーを選択してね！", 360, 80);
        gc.DrawImage(6, 20, 190);
        gc.DrawImage(7, 370, 190);

        gc.DrawImage(23, 0, 505);
        gc.DrawCenterString("このプレイヤーでよろしいですか？", 360, 600);
        gc.DrawImage(26, 100, 690);
        gc.DrawImage(16, 430, 770);//すすむボタン
        gc.DrawImage(15, 430, 920); //もどるボタン

        gc.DrawImage(23, 0, 1180);
      }
      else if(gameState == 3)
      { //男の子確認
        gc.SetFontSize(40);
        gc.DrawCenterString("プレイヤーを選択してね！", 360, 80);
        gc.DrawImage(6, 20, 190);
        gc.DrawImage(7, 370, 190);

        gc.DrawImage(23, 0, 505);
        gc.DrawCenterString("このプレイヤーでよろしいですか？", 360, 600);
        gc.DrawImage(27, 100, 690);
        gc.DrawImage(16, 430, 770);//すすむボタン
        gc.DrawImage(15, 430, 920); //もどるボタン
        gc.DrawImage(23, 0, 1180);
      }

      else if(gameState == 4)
      { //女の子用プレイ画面
        gc.SetColor(201,231,248);
        gc.FillRect(0, 0, 720, 1280);//背景の空

        gc.DrawImage(3, 0, 1078);
        gc.DrawImage(player_img, player_x, player_y);
        if(time>=0 && time<=600)
        {
          gc.DrawImage(47, 420, 50);//太陽汗
        }
        else
        {
          gc.DrawImage(45, 420, 50);//太陽
        }



        for(int i =0 ; i < BALL_NUM ; i ++ ){
          gc.DrawImage(ball_type[i],ball_x[i],ball_y[i]);
        }

        gc.SetColor(52,90,119);
        gc.SetFontSize(40);

        gc.DrawString("制限時間："+time/60+"秒",0,0);
        gc.DrawString("総取得単位数："+score,0,40);
        if(time>=0 && time<=600)
        {
          gc.DrawString("そろそろ放塾の危機では？",0,80);
        }
        else{
          gc.DrawString("単位集め頑張ろう！", 0, 80);
        }

        gc.DrawImage(28, 100, 1150);
        gc.DrawImage(29, 470, 1150);
      }

      else if(gameState == 5)
      { //男の子用プレイ画面
        gc.SetColor(201,231,248);
        gc.FillRect(0, 0, 720, 1280);

        gc.DrawImage(3, 0, 1078);
        gc.DrawImage(player_img, player_x, player_y);
        if(time>=0 && time<=600)
        {
          gc.DrawImage(47, 420, 50);//太陽汗
        }
        else
        {
          gc.DrawImage(45, 420, 50);//太陽
        }

        for(int i =0 ; i < BALL_NUM ; i ++ ){
          gc.DrawImage(ball_type[i],ball_x[i],ball_y[i]);
        }

        gc.SetColor(52,90,119);
        gc.SetFontSize(40);
        gc.DrawString("制限時間："+time/60+"秒",0,0);
        gc.DrawString("総取得単位数："+score,0,40);
        if(time>=0 && time<=600)
        {
          gc.DrawString("そろそろ放塾の危機では？",0,80);
        }
        else{
          gc.DrawString("単位集め頑張ろう！", 0, 80);
        }

        gc.DrawImage(28, 100, 1150);
        gc.DrawImage(29, 470, 1150);
      }

      else if (gameState == 6)
      {
        //ゲームオーバー(放塾&落単)時の処理(男女)
        gc.SetColor(46, 75, 98);
        gc.FillRect(0, 0, 720, 1280);
        gc.DrawImage(46, 40, 220);
        gc.SetColor(225,224,223);
        gc.DrawString("制限時間：GAME OVER!!",0,0);
        gc.DrawString("総取得単位数："+score,0,40);
        gc.DrawString("放塾...", 0, 80);
        
        gc.DrawImage(3, 0, 1078);
        gc.DrawImage(player_img, player_x, player_y +72);
        gc.DrawImage(19, 258, 1120); //続きをみるボタン
      }
      else if (gameState ==7){
        //卒業時の処理(男女)
        gc.SetColor(201,231,248);
        gc.FillRect(0, 0, 720, 1280);
        gc.DrawImage(45, 420, 50);//太陽
        gc.DrawImage(48, 75, 400);//虹

        gc.SetColor(52,90,119);
        gc.DrawString("制限時間：CLEAR!!",0,0);
        gc.DrawString("総取得単位数："+score,0,40);
        gc.DrawString("卒業おめでとう！！", 0, 80);
        gc.DrawImage(38, 0, 1078);
        gc.DrawImage(player_img, player_x, player_y);
        gc.DrawImage(19, 258, 1120); //続きをみるボタン
      }
      else if (gameState ==8){
        //落単エンディング
        gc.SetColor(0,0,0);
        gc.SetFontSize(60);
        gc.DrawCenterString("放塾END", 360, 50);
        
        gc.DrawImage(21, 20, 200);
        gc.DrawImage(22, 400, 200);
        gc.SetFontSize(17);
        gc.DrawCenterString("ああぁぁあぁああぁああぁ", 360, 400);
        gc.DrawImage(23, 0, 650);
        gc.SetFontSize(30);
        gc.DrawCenterString("必要な単位数を期限内に集められなかったあなたは", 360, 750);
        gc.DrawCenterString("無事に放塾となった...", 360, 820);
        gc.DrawImage(23, 0, 934);
        gc.DrawImage(20, 283, 1070);//TOPにもどるボタン
      }
      else if (gameState ==9){
        //卒業エンディング
        gc.SetColor(0,0,0);
        gc.SetFontSize(60);
        gc.DrawCenterString("卒業END", 360, 50);
        
        gc.DrawImage(43, 520, 180);///桜フレーム
        gc.DrawImage(40, 40, 220);
        gc.DrawImage(41, 481, 220);
        gc.DrawImage(39, 285, 313); //諭吉
        gc.DrawImage(42, 0, 450);///桜フレーム
        gc.SetFontSize(25);
        gc.DrawCenterString("やったね！", 360, 500);
        gc.DrawImage(23, 0, 650);
        gc.SetFontSize(30);
        gc.DrawCenterString("必要な単位数を期限内に集められたあなたは", 360, 750);
        gc.DrawCenterString("無事に卒業できた！", 360, 820);
        gc.DrawImage(23, 0, 934);
        gc.DrawImage(20, 283, 1070);//TOPにもどるボタン
        }
    }

    void resetBall(int id){
      ball_x[id] = gc.Random(0,616);
      ball_y[id] = -gc.Random(24,480);
      ball_speed[id] = gc.Random(3,6);
      ball_type[id] = gc.Random(32,37); //ballのcolorが32から37のrandomな数字= img8からmg13の内のどれか
    }

    
    
}