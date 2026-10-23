# Contributing

Thanks for helping improve the Employee Management API. Keep changes focused, reviewable, and easy to test.

## Development workflow

1. Create a branch from the latest `main` branch.
2. Use a descriptive branch name, such as `feat/employee-search`, `fix/profile-image-validation`, or `docs/setup-guide`.
3. Keep each change focused on one concern.
4. Do not commit build output, local IDE settings, secrets, or personal data.
5. Update the README or API documentation when behavior or setup changes.
6. Open a pull request with a clear summary and testing notes.

## Before opening a pull request

Run these commands from the repository root:

~~~powershell
dotnet restore .\AngularApi.sln
dotnet build .\AngularApi.sln --configuration Release
~~~

If tests are added, run the relevant test suite and include the result in the pull request.

## Commit messages

Use a short, imperative summary. Examples:

- `feat: add employee search`
- `fix: validate profile image deletion`
- `docs: clarify local database setup`
- `chore: update repository hygiene`

## Pull request checklist

- [ ] The change has a clear purpose and limited scope.
- [ ] The solution builds successfully.
- [ ] Documentation is updated when needed.
- [ ] No secrets, generated output, or personal data are included.
- [ ] API behavior and error cases have been considered.
