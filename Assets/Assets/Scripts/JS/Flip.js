 #pragma strict
 
 var Speed : float = 40f;
 var isGrounded : boolean;
 var canClimb : boolean;
 var groundedEnd : Transform;
 var climbingEnd : Transform;
 var h : float = 0.0;
 var v : float = 0.0;
 var facingRight : boolean = true;
 var facingUp : boolean = true;
 
 function Start () {
 
  
 }
 
 function FixedUpdate () {
     movement();
     h = Input.GetAxis("Horizontal");
     v = Input.GetAxis("Vertical");
 }
 
 function movement(){
     if (h!= 0 && !canClimb){
         transform.Translate (Vector2(h * Speed * Time.deltaTime,0));
     }
     if (h < 0 && facingRight)
     {
         Flip();
         print("!facingRight");
     }
     else if (h > 0 && !facingRight)
     {
         Flip();
         print("facingRight");
     }
 }
 function Flip ()
     {
     if(facingRight==true){
         facingRight = false;
         transform.localScale = new Vector2(transform.localScale.x * -1, 25f);
         }
     else if(facingRight==false){
         facingRight = true;
         transform.localScale = new Vector2(transform.localScale.x * -1, 25f);
         }
     }
     