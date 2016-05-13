#pragma strict



	function OnCollisionEnter2D(coll: Collision2D)
 {
	 
     if( coll.gameObject.tag == "Deadly")
     {
         Destroy(gameObject);
     }
 }
