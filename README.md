# Auth0 Coding Project

<p align="left">
  <a href="https://github.com/olegburov/Auth0/actions"><img alt="GitHub Actions status" src="https://github.com/olegburov/Auth0/workflows/ASP.NET%20Core%20CI/badge.svg"></a>
</p>

[![Build Status](https://dev.azure.com/olegburov/Auth0/_apis/build/status/olegburov.Auth0?branchName=master)](https://dev.azure.com/olegburov/Auth0/_build/latest?definitionId=10&branchName=master)

## Problem Overview

Auth0 allows customers to create tokens to protect their own APIs (https://auth0.com/docs/api-auth) using standard OAuth2 flows. As part of the configuration Auth0 allows to define a know lists of scopes available for APIs that might be used to display consent forms and it allows developers to modify the scopes that will be included in the resulting tokens. 

## Requirements

Provide a solution that allows a customer to define limited access to their API:

1. The user authenticates using Auth0
2. Based on the user job title the user may have access to
   - Read Data
   - Write Data or
   - Delete Data
3. The application gets a token to act on behalf of the user
4. The application calls the API to perform any activities

Build a sample application (SPA or Web Application) and a dummy service that depict the flow required to implement the authentication and the API Call.

## Extra credit

- Do not use the `Authorization Extension`.
- Enable usage of `refresh_token` for mobile applications.
- Add your own custom rule (not from a template) that enriches the user profile.

Please share the code on GitHub and make sure the README file is clean and clear so customers can understand it.

## Application flow diagram

![](Schema.png) 

## Getting started

1. Navigate at URL https://onegit-webapp.azurewebsites.net/.

2. Log in using one of the following predefined users:

   - User with the access right `Read Data`.

     * Login: `viewer@olegburov.com`
     * Password: `Viewer2User`
   
   - User with the access right `Write Data`.

     * Login: `editor@olegburov.com`
     * Password: `Editor2User`

   - User with the access right `Delete Data`.
 
     * Login: `admin@olegburov.com`
     * Password: `Admin2User`

3. Depending on a user's access right, a security role is assigned with the following scope(s) for calling back-end Web API.

   - The access right `Read Data`

      * Role: `reader`
      * Scope: `read:repositories`

   - The access right `Write Data`

      * Role: `editor`
      * Scope: `create:repositories`, `read:repositories` and `update:repositories`
   
   - The access right `Delete Data`
     
      * Role: `admin`
      * Scope: `create:repositories`, `read:repositories`, `update:repositories` and `delete:repositories`

4. Based on a user's role, the front-end WebApp provides differente actions for a user:

   - The role `reader`

      * View existent repositories
   
   - The role `editor`
   
      * View existent repositories 
      * Create new repositories
      * Edit existent repositories

   - The role `admin`
   
      * View existent repositories 
      * Create new repositories
      * Edit existent repositories  
      * Delete existent repositories

5. When a user perform granted actions, the front-end WebApp communicates with back-end WebAPI (https://onegit-webapi.azurewebsites.net) using an `access_token` to invoke these actions on behalf of a user.

6. The `access_token` includes a granted scope(s) based on a user's role.

7. The WebAPI provides the following endpoints where each requres a specific scope to be executed:

   - The **List Repositories** operation returns a list of the repositories currently in a database. 

     `GET https://{base-url}/api/repositories`
  
     > The scope `read:repositories` is required for service requests.

   - The **Get Repository** operation gets a repository from a database.
   
     `GET https://{base-url}/api/repositories/{repository-guid}`

     > The scope `read:repositories` is required for service requests.

   - The **Create Repository** operation creates a new repository in a database.
   
     `POST https://{base-url}/api/repositories`

     > The scope `create:repositories` is required for service requests.

   - The **Update Repository** operation updates an existent repository to the new one.
   
     `PUT https://{base-url}/api/repositories/{repository-guid}`

     > The scope `update:repositories` is required for service requests.
     
   - The **Delete Repository** operation removes an repository from database.
   
     `DELETE https://{base-url}/api/repositories/{repository-guid}`

     >  The scope `delete:repositories` is required for service requests.
