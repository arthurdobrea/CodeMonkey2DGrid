using System.Collections;
using UnityEngine;

public class TurnBasedController : MonoBehaviour
{
    private bool isExecutingTurn = false;
    [SerializeField] public GameObject[] turnBasedCharacters;
    [SerializeField] private BoolEvent playerCanMove;
    private int currentIndex = 0;

    public void MakeMoveForAllCharacters()
    {
        Debug.Log("StartingTurnBase");
        currentIndex = 0;
        StartCoroutine(TurnBasedSystem());
    }

    IEnumerator TurnBasedSystem()
    {
        while (currentIndex != turnBasedCharacters.Length)
        {
            yield return StartCoroutine(ExecuteTurn());

            // Move to the next character in the list
            ++currentIndex;

            // Reset the flag to indicate that the turn has finished
            isExecutingTurn = false;
        }

        Debug.Log("All characters made moves");
        playerCanMove.Raise(true);
        // Wait for the next frame before starting the next turn
        yield return null;
    }


    IEnumerator ExecuteTurn()
    {
        // Get the current character
        ITurnBasedCharachter currentCharacter = turnBasedCharacters[currentIndex].GetComponent<ITurnBasedCharachter>();

        // Your turn logic goes here for the current character
        Debug.Log($"Executing turn for {currentCharacter.Name}");

        currentCharacter.MakeMove();
        // Simulate some action (replace this with your actual turn logic)
        yield return null;

        // Turn is complete for the current character
        Debug.Log($"Turn complete for {currentCharacter.Name}");
    }

// IEnumerator TurnBasedSystem()
// {
//     while (currentIndex != turnBasedCharacters.Length - 1) 
//     {
//         // Check if the turn is currently being executed
//         if (!isExecutingTurn)
//         {
//             // Set flag to indicate that the turn is starting
//             isExecutingTurn = true;
//
//             // Execute the turn for the current character
//             yield return StartCoroutine(ExecuteTurn());
//
//             // Move to the next character in the list
//             currentIndex = (currentIndex + 1) % turnBasedCharacters.Length;
//
//             // Reset the flag to indicate that the turn has finished
//             isExecutingTurn = false;
//         }
//
//         // Wait for the next frame before starting the next turn
//         yield return null;
//     }
// }
//
// IEnumerator ExecuteTurn()
// {
//     // Get the current character
//     ITurnBasedCharachter currentCharacter = turnBasedCharacters[currentIndex].GetComponent<ITurnBasedCharachter>();
//     
//     // Your turn logic goes here for the current character
//     Debug.Log($"Executing turn for {currentCharacter.Name}");
//     
//     // Simulate some action (replace this with your actual turn logic)
//     yield return new WaitForSeconds(2.0f);
//     
//     // Turn is complete for the current character
//     Debug.Log($"Turn complete for {currentCharacter.Name}");
// }
}