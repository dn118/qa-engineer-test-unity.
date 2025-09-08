# QA Engineer Unity Test Project

This project is a simple Unity application with automated **EditMode** and **PlayMode** tests.  
It was created as part of a QA Engineer test task to demonstrate skills in writing Unity tests using **NUnit** and **Unity Test Framework**.

---

## 📋 Prerequisites

Before you begin, make sure you have the following installed:

- [Unity Hub](https://unity.com/download)  
- Unity Editor **2022.3 LTS** (or compatible)  
- [.NET SDK](https://dotnet.microsoft.com/en-us/download) (if needed for external builds)  
- Git

---

## ⚙️ Setup Instructions

1. **Clone the repository**  
   ```bash
   git clone https://github.com/dn118/qa-engineer-test-unity.git
   cd qa-engineer-test-unity
2. Open the project in Unity

Launch Unity Hub.

Add the cloned folder as an existing Unity project.

Open it in Unity Editor.

3. Run the tests

Go to Window → General → Test Runner.

Select EditMode or PlayMode tab.

Press Run All.

✅ All tests should pass successfully.
4. Implemented Tests

Button_Disabled_After_Ten_Clicks – verifies that the button becomes disabled after 10 clicks.

Button_IsInteractable – verifies that the button is initially interactable.

Counter_Equals_10_After_Ten_Clicks – verifies that the counter value equals 10 after 10 clicks.

Counter_Increases_On_Click – verifies that the counter increases by 1 per click.

Project Structure:
Assets/
 ├── EditModeTests/       # Unit tests running in Edit Mode
 ├── PlayModeTests/       # Integration tests running in Play Mode
 ├── Scripts/             # Game logic scripts
 ├── Scenes/              # Unity scenes


