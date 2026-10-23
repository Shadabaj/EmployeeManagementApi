# Security Policy

## Reporting a vulnerability

Please do not report security vulnerabilities, credentials, or sensitive employee data in a public issue.

Use GitHub's private vulnerability reporting feature for this repository if it is enabled. Otherwise, contact the repository owner privately through GitHub and include only the information needed to understand and reproduce the issue.

## Safe configuration

- Keep database credentials, tokens, and production connection strings out of source control.
- Use environment variables or a local secret store for developer-specific configuration.
- Restrict CORS to trusted origins in deployed environments.
- Validate and authorize requests that read, change, or delete employee records and profile images.
