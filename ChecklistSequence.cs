//using System.Collections;
//using System.Collections.Generic;
//using Framework.GameFoundation.Interaction;
//using UnityEngine;
//using UnityEngine.Events;
//using HurricaneVR.Framework.ControllerInput;
//using HurricaneVR.Framework.Core.Utils;

//public class ChecklistSequence : MonoBehaviour
//{
//    public HVRGlobalInputs hvrControllers;
//    public VirtualRealityInteractor realityInteractor;

//    private Interactable interactable;
//    public List<GameObject> Checked = new List<GameObject>();
//    public List<GameObject>  checklistItems;
//    public List<GameObject> buttons;
//    public List<GameObject> targetGameObjects;
//    private int currentIndex = 0;
//    private bool clicked = false;
//    public int checkedItem;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (gameObject.CompareTag("Untagged") == true && hvrControllers.RightTrigger == 1)
//        {
//            gameObject.tag = "Checked";
//            Debug.Log("The trigger was pressed and gameobject was untagged.");
//        }

//        if (hvrControllers.RightTrigger == 1)
//        {
//            //ButtonsCheck();
//            // clicked = true;
//            // if (clicked == true)
//            // {
//            //     CheckOutlines();
//            // }
//            // Debug.Log("THE RIGHT TRIGGER BUTTON WAS PRESSED");
//            ChecklistOutlines();
//        }
        
//    }

//    public void ButtonsCheck()
//    {
//        for (int i = 0; i < buttons.Count; i++)
//        {
//            if (buttons[i].gameObject.activeInHierarchy == true)
//            {
//                CheckItems();
//            }

//        }
//    }

//    private void CheckItems()
//    {
//        for (int i = 0; i < checklistItems.Count; i++)
//        {
//            if (checklistItems[i].gameObject.GetComponent<Outline>().enabled == false)
//            {
//                isItem(true);
//                Checked.Add(checklistItems[i].gameObject);
//                Debug.Log("The items have been checked.");
//            }
//            else
//            {
//                // Checked.Add(checklistItems[i].gameObject);
//                isItem(false);
//                Debug.Log("The bool is off.");
//                Debug.Log("Outline was switched off.");
//                break;
//            }

//        }

//    }

//    private bool isItem(bool check)
//    {
//        if (check == true)
//        {
//            return true;
//        }
//        return false;
//    }

//    public void ChangeTag()
//    {
//        foreach (GameObject item in checklistItems)
//        {
//            item.gameObject.tag = "Checked";
//            Debug.Log("The tag was changed.");
//        }
//    }

//    public void CheckOutlines()
//    {
//        //Checked.Clear();
//        foreach (GameObject obj in checklistItems)
//        {
//            Outline outline = obj.GetComponent<Outline>();
//            if (outline != null && clicked == true && outline.enabled == true)
//            {
//                Checked.Add(obj);
//            }
//        }
//    }

//    public void ChecklistOutlines()
//    {
//        if (currentIndex < targetGameObjects.Count)
//        {
//            GameObject currentTarget = targetGameObjects[currentIndex];

//            if (currentTarget.CompareTag("Untagged") == true && hvrControllers.RightTrigger == 1)
//            {
//                currentTarget.tag = "Checked";
//                Debug.Log("Trigger was pressed and target gameobject was untagged");
//                currentIndex++;
//            }
//        }
//    }

//    public void OnDisable()
//    {
//        ChangeTag();
//        checkedItem += 1;
//    }
//}
