using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TownMovement : MonoBehaviour {

    private GameObject shop;
    private ShopManager shopManager;
    private GameObject quests;
    private QuestBook questBook;
    private GameObject player;

    // NPC dialogue collection
    public TextMeshProUGUI dialogueDisplay;
    public GameObject guestDisplay;

    public GameObject place1;
    public GameObject place2;
    public GameObject place3;
    public GameObject place4;
    public GameObject place5;
    public GameObject place6;
    public GameObject place7;
    public GameObject place8;
    public GameObject place9;
    public GameObject place10;
    public GameObject place11;
    public GameObject place12;
    public GameObject place13;
    public GameObject place14;
    public GameObject place15;
    public GameObject place16;
    public GameObject place17;
    public GameObject place18;
    public GameObject place19;
    public GameObject place20;
    public GameObject place21;
    public GameObject place22;
    public GameObject place23;
    public GameObject place24;
    public GameObject place25;

    private Vector3 playerPos;
    private Vector3 currentPos;

    private Vector3 place_1;
    private Vector3 place_2;
    private Vector3 place_3;
    private Vector3 place_4;
    private Vector3 place_5;
    private Vector3 place_6;
    private Vector3 place_7;
    private Vector3 place_8;
    private Vector3 place_9;
    private Vector3 place_10;
    private Vector3 place_11;
    private Vector3 place_12;
    private Vector3 place_13;
    private Vector3 place_14;
    private Vector3 place_15;
    private Vector3 place_16;
    private Vector3 place_17;
    private Vector3 place_18;
    private Vector3 place_19;
    private Vector3 place_20;
    private Vector3 place_21;
    private Vector3 place_22;
    private Vector3 place_23;
    private Vector3 place_24;
    private Vector3 place_25;

    public float speed = 0.05f;

    public bool one;
    public bool two;
    public bool three;
    public bool four;
    public bool five;
    public bool six;
    public bool seven;
    public bool eight;
    public bool nine;
    public bool ten;
    public bool eleven;
    public bool twelve;
    public bool thirteen;
    public bool fourteen;
    public bool fifteen;
    public bool sixteen;
    public bool seventeen;
    public bool eighteen;
    public bool nineteen;
    public bool twenty;
    public bool twentyOne;
    public bool twentyTwo;
    public bool twentyThree;
    public bool twentyFour;
    public bool twentyFive;

    void Start() {

        player = GameObject.Find("Player");

        place_1 = place1.transform.position;
        place_2 = place2.transform.position;
        place_3 = place3.transform.position;
        place_4 = place4.transform.position;
        place_5 = place5.transform.position;
        place_6 = place6.transform.position;
        place_7 = place7.transform.position;
        place_8 = place8.transform.position;
        place_9 = place9.transform.position;
        place_10 = place10.transform.position;
        place_11 = place11.transform.position;
        place_12 = place12.transform.position;
        place_13 = place13.transform.position;
        place_14 = place14.transform.position;
        place_15 = place15.transform.position;
        place_16 = place16.transform.position;
        place_17 = place17.transform.position;
        place_18 = place18.transform.position;
        place_19 = place19.transform.position;
        place_20 = place20.transform.position;
        place_21 = place21.transform.position;
        place_22 = place22.transform.position;
        place_23 = place23.transform.position;
        place_24 = place24.transform.position;
        place_25 = place25.transform.position;

        one = true;
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.name == "NPCs") {
            Debug.Log("Hit own player");
        }

        if (other.gameObject.name == "Place 1") {
            //Debug.Log("1 - 2, 5");
            one = false;
            int num = (int)Random.Range(1, 3);
            if (num == 1) {
                two = true;
            } else {
                five = true;
            }
        }
        // error prone
        if (other.gameObject.name == "Place 2") {
            //Debug.Log("2 - 1, 3, 16, 24");
            two = false;
            int num = (int)Random.Range(1, 5);
            Debug.Log(num);

            if (num == 1) {
                one = true;
            } 
            if (num == 2) {
                three = true;
            }
            if (num == 3) {
                sixteen = true;
            }
            if (num == 4) {
                twentyFour = true;
            }
        }
        if (other.gameObject.name == "Place 3") {
            //Debug.Log("3 - 2, 4, 25");
            three = false;
            int num = (int)Random.Range(1, 4);
            if (num == 1) {
                two = true;
            } 
            if (num == 2) {
                four = true;
            }
            if (num == 3) {
                twentyFive = true;
            }
        }
        if (other.gameObject.name == "Place 4") {
            //Debug.Log("4 - 3, 5, 6");
            four = false;
            int num = (int)Random.Range(1, 4);
            if (num == 1) {
                three = true;
            } 
            if (num == 2) {
                five = true;
            }
            if (num == 3) {
                six = true;
            }
        }
        if (other.gameObject.name == "Place 5") {
            //Debug.Log("5 - 4, 1");
            five = false;
            int num = (int)Random.Range(1, 3);
            if (num == 1) {
                four = true;
            } else {
                one = true;
            }
        }
        // error prone
        if (other.gameObject.name == "Place 6") {
            //Debug.Log("6 - 4, 7, 8");
            six = false;
            int num = (int)Random.Range(1, 4);
            Debug.Log(num);
            if (num == 1) {
                four = true;
            } 
            if (num == 2) {
                seven = true;
            }
            if (num == 3) {
                eight = true;
            }
        }
        if (other.gameObject.name == "Place 7") {
            //Debug.Log("7 - 6");
            seven = false;
            int num = (int)Random.Range(1, 2);
            if (num == 1) {
                six = true;
            } 
        }
        if (other.gameObject.name == "Place 8") {
            //Debug.Log("8 - 6");
            eight = false;
            int num = (int)Random.Range(1, 2);
            if (num == 1) {
                six = true;
            } 
        }
        if (other.gameObject.name == "Place 9") {
            //Debug.Log("9 - 6, 10, 11, 12");
            nine = false;
            int num = (int)Random.Range(1, 5);
            if (num == 1) {
                six = true;
            }
            if (num == 2) {
                ten = true;
            }
            if (num == 3) {
                eleven = true;
            }
            if (num == 4) {
                twelve = true;
            }
        }
        if (other.gameObject.name == "Place 10") {
            //Debug.Log("10 - 9");
            ten = false;
            int num = (int)Random.Range(1, 2);
            if (num == 1) {
                nine = true;
            } 
        }
        if (other.gameObject.name == "Place 11") {
            //Debug.Log("11 - 9");
            eleven = false;
            int num = Random.Range(1, 2);
            if (num == 1) {
                nine = true;
            } 
        }
        if (other.gameObject.name == "Place 12") {
            //Debug.Log("12 - 9, 13, 14, 15");
            twelve = false;
            int num = (int)Random.Range(1, 5);
            Debug.Log(num);

            if (num == 1) {
                nine = true;
            }
            if (num == 2) {
                thirteen = true;
            }
            if (num == 3) {
                fourteen = true;
            }
            if (num == 4) {
                fifteen = true;
            }
        }
        if (other.gameObject.name == "Place 13") {
            //Debug.Log("13 - 12");
            thirteen = false;
            int num = (int)Random.Range(1, 2);
            if (num == 1) {
                twelve = true;
            } 
        }
        if (other.gameObject.name == "Place 14") {
            //Debug.Log("14 - 12");
            fourteen = false;
            int num = (int)Random.Range(1, 2);
            if (num == 1) {
                twelve = true;
            } 
        }
        if (other.gameObject.name == "Place 15") {
            //Debug.Log("15 - 12");
            fifteen = false;
            int num = (int)Random.Range(1, 2);
            if (num == 1) {
                twelve = true;
            } 
        }
        if (other.gameObject.name == "Place 16") {
            //Debug.Log("16 - 2, 17, 18, 19");
            sixteen = false;
            int num = (int)Random.Range(1, 5);
            if (num == 1) {
                two = true;
            }
            if (num == 2) {
                seventeen = true;
            }
            if (num == 3) {
                eighteen = true;
            }
            if (num == 4) {
                nineteen = true;
            }
        }
        if (other.gameObject.name == "Place 17") {
            //Debug.Log("17 - 16");
            seventeen = false;
            int num = (int)Random.Range(1, 2);
            if (num == 1) {
                sixteen = true;
            } 
        }
        if (other.gameObject.name == "Place 18") {
            //Debug.Log("18 - 16");
            eighteen = false;
            int num = (int)Random.Range(1, 2);
            if (num == 1) {
                sixteen = true;
            } 
        }
        // error prone
        if (other.gameObject.name == "Place 19") {
            //Debug.Log("19 - 20, 21, 22, 16");
            nineteen = false;
            int num = (int)Random.Range(1, 5);
            Debug.Log(num);

            if (num == 1) {
                twenty = true;
            }
            if (num == 2) {
                twentyOne = true;
            }
            if (num == 3) {
                twentyTwo = true;
            }
            if (num == 4) {
                sixteen = true;
            }
        }
        if (other.gameObject.name == "Place 20") {
            //Debug.Log("20 - 19");
            twenty = false;
            int num = (int)Random.Range(1, 2);
            if (num == 1) {
                nineteen = true;
            } 
        }
        if (other.gameObject.name == "Place 21") {
            //Debug.Log("21 - 19");
            twentyOne = false;
            int num = (int)Random.Range(1, 2);
            if (num == 1) {
                nineteen = true;
            } 
        }
        // error prone
        if (other.gameObject.name == "Place 22") {
            //Debug.Log("22 - 19, 23");
            twentyTwo = false;
            int num = (int)Random.Range(1, 3);
            Debug.Log(num);

            if (num == 1) {
                nineteen = true;
            } else {
                twentyThree = true;
            }
        }
        if (other.gameObject.name == "Place 23") {
            //Debug.Log("23 - 22");
            twentyThree = false;
            int num = (int)Random.Range(1, 2);
            if (num == 1) {
                twentyTwo = true;
            } 
        }
        if (other.gameObject.name == "Place 24") {
            //Debug.Log("24 - 2");
            twentyFour = false;
            int num = (int)Random.Range(1, 2);
            if (num == 1) {
                two = true;
            } 
        }
        if (other.gameObject.name == "Place 25") {
            //Debug.Log("25 - 3");
            twentyFive = false;
            int num = (int)Random.Range(1, 2);
            if (num == 1) {
                three = true;
            } 
        }
    }

    void FixedUpdate() {

        if (one) {
            One();
        }
        if (two) {
            Two();
        }
        if (three) {
            Three();
        }
        if (four) {
            Four();
        }
        if (five) {
            Five();
        }
        if (six) {
            Six();
        }
        if (seven) {
            Seven();
        }
        if (eight) {
            Eight();
        }
        if (nine) {
            Nine();
        }
        if (ten) {
            Ten();
        }
        if (eleven) {
            Eleven();
        }
        if (twelve) {
            Twelve();
        }
        if (thirteen) {
            Thirteen();
        }
        if (fourteen) {
            Fourteen();
        }
        if (fifteen) {
            Fifteen();
        }
        if (sixteen) {
            Sixteen();
        }
        if (seventeen) {
            Seventeen();
        }
        if (eighteen) {
            Eighteen();
        }
        if (nineteen) {
            Nineteen();
        }
        if (twenty) {
            Twenty();
        }
        if (twentyOne) {
            TwentyOne();
        }
        if (twentyTwo) {
            TwentyTwo();
        }
        if (twentyThree) {
            TwentyThree();
        }
        if (twentyFour) {
            TwentyFour();
        }
        if (twentyFive) {
            TwentyFive();
        }
    }

    void One() {

        currentPos = this.transform.position;

        switch (place_1.x < currentPos.x, place_1.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }

    void Two() {

        currentPos = this.transform.position;

        switch (place_2.x < currentPos.x, place_2.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }

    void Three() {

        currentPos = this.transform.position;

        switch (place_3.x < currentPos.x, place_3.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }

    void Four() {

        currentPos = this.transform.position;

        switch (place_4.x < currentPos.x, place_4.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }

    void Five() {

        currentPos = this.transform.position;

        switch (place_5.x < currentPos.x, place_5.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }

    void Six() {

        currentPos = this.transform.position;

        switch (place_6.x < currentPos.x, place_6.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void Seven() {

        currentPos = this.transform.position;

        switch (place_7.x < currentPos.x, place_7.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void Eight() {

        currentPos = this.transform.position;

        switch (place_8.x < currentPos.x, place_8.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void Nine() {

        currentPos = this.transform.position;

        switch (place_9.x < currentPos.x, place_9.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void Ten() {

        currentPos = this.transform.position;

        switch (place_10.x < currentPos.x, place_10.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void Eleven() {

        currentPos = this.transform.position;

        switch (place_11.x < currentPos.x, place_11.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void Twelve() {

        currentPos = this.transform.position;

        switch (place_12.x < currentPos.x, place_12.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void Thirteen() {

        currentPos = this.transform.position;

        switch (place_13.x < currentPos.x, place_13.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void Fourteen() {

        currentPos = this.transform.position;

        switch (place_14.x < currentPos.x, place_14.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void Fifteen() {

        currentPos = this.transform.position;

        switch (place_15.x < currentPos.x, place_15.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void Sixteen() {

        currentPos = this.transform.position;

        switch (place_16.x < currentPos.x, place_16.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void Seventeen() {

        currentPos = this.transform.position;

        switch (place_17.x < currentPos.x, place_17.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void Eighteen() {

        currentPos = this.transform.position;

        switch (place_18.x < currentPos.x, place_18.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void Nineteen() {

        currentPos = this.transform.position;

        switch (place_19.x < currentPos.x, place_19.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void Twenty() {

        currentPos = this.transform.position;

        switch (place_20.x < currentPos.x, place_20.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void TwentyOne() {

        currentPos = this.transform.position;

        switch (place_21.x < currentPos.x, place_21.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void TwentyTwo() {

        currentPos = this.transform.position;

        switch (place_22.x < currentPos.x, place_22.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void TwentyThree() { 

        currentPos = this.transform.position;

        switch (place_23.x < currentPos.x, place_23.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void TwentyFour() {

        currentPos = this.transform.position;

        switch (place_24.x < currentPos.x, place_24.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
    void TwentyFive() {

        currentPos = this.transform.position;

        switch (place_25.x < currentPos.x, place_25.y < currentPos.y) {
            case (true, true):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (true, false):
                currentPos = new Vector3(currentPos.x - speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
            case (false, true):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y - speed / 1.41f, currentPos.z);
                break;
            case (false, false):
                currentPos = new Vector3(currentPos.x + speed / 1.41f, currentPos.y + speed / 1.41f, currentPos.z);
                break;
        }
        this.transform.position = currentPos;
    }
}
