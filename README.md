# group4msauto
## Introduction

FinalProject is an automation project for testing Asset Management

## Project Structure

The project is organized as the structure below

- **Data**: Includes data driven files
- **Helpers**: 
  - Automation_Test_Framework contains all base methods of pages
  - Core_Framework contains all base methods of test/driver interaction
- **Pages**: Includes pages
  - HomePage.cs
  - LoginPage.cs
  - ManageAssetPage.cs
  - ManageAssignmentPage.cs
  - ManageUserPage.cs
  - So on...
- **Results**: Includes test results/reports after executing tests 
- **Tests**: Includes all tests scripts divided by features
  - APITest.cs
  - LoginTest.cs
  - LogoutTest.cs
  - ManageAssetTest.cs
  - ManageAssignmentTest.cs
  - ManageUserTest.cs



## Coding Convention

Examples for pages

```bash
HomePage.cs

*** Settings ***
Library    SeleniumLibrary

*** Variables ***
${SEARCH_BOX} =     xpath://*[@id="gh-ac"]
${SEARCH_TEXT} =    mobile

*** Keywords ***
Input Search Text and Click Search
    Input Text    //*[@id="gh-ac"]   mobile
    Press Keys    //*[@id="gh-btn"]  RETURN

Click on Advanced Search
    wait until page contains element    //*[@id="gh-as-a"]
    Click Element    //*[@id="gh-as-a"]
```

Tests examples

```bash
*** Settings ***
Documentation    Verify search functionality
Resource    ../Pages/SearchResultPage.robot
Resource    ../Pages/LandingPage.robot
Resource    ../Helperes/Common.robot

Test Setup  Common.Start Test
Test Teardown   Common.Finish Test

*** Test Cases ***
Verify basic search funtionality
    [Documentation]    Basic search
    [Tags]    Search    Functionality
    LandingPage.Search For Somethings
    SearchResultPage.Verify Search Results

Verify advanced search funtionality
    [Documentation]    Addvanced Search
    [Tags]    Search    Functionality
    LandingPage.Search For Somethings In Advanced
    SearchResultPage.Verify Search Results
```

## Gitflow

1/ Create new branch
```bash
git checkout -b {branch-name}
```

2/ Do your changes

3/ Change files which we want to commit to Staged status

4/ Commit your codes
```bash
git commit -m "{message}"
```
5/ Check commit logs
```bash
git log
```
or
```bash
git log --oneline
```

6/ If the log is great, push your local commit to remote repo

```bash
git push origin {branch-name}
```

7/ Create a PR to merge my branch into main

8/ Ping other team members to review my PR

9/ Read comments and fix them

10/ Commit changes and push your commits

11/ If other members are approved your PR, please merge it with squash merge mode. If there are conflicts, please rebase main branch followed these steps below

- Switch to main branch and get latest code

```bash
git checkout main
git pull origin main
```
- Switch to your branch and rebase

```bash
git checkout -
git rebase main
```
- Resolve conflicts one by one in each file
- Continue rebase

```bash
git rebase --continue
```
- IF there are some changed files, please commit your source code as a new commit

```bash
git commit -m "{message}"
```
- Push code to remote repo
```bash
git push origin {branch-name}
```

*/ If you want to hard commit to the last commit try to use:

```bash
git commit --amend --no-edit
```

