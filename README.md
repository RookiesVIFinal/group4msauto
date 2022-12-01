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

...

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

