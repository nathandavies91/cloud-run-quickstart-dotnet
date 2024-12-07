# This is a quickstart template for building a dotnet core RESTful API, using GCP Cloud Run and Firestore

**What's included:**

1. RESTful dotnet core solution, with:
2. An example controller (ItemsController) which does some simple adding and retrieving of 'items'
3. The supporting ItemsService which handles the communication with Firestore
4. Relevant Item model for which objects get coverted to
5. Gitlab and cloudbuild instructions to deploy the application to Cloud Run via Cloud Build

Item is just an example collection reference.
You can use this as a basis for your own collections.

## GCP set-up / prerequisites

1. You will need to have set-up a Cloud Run service; if you call it anything other than `api` then this will need to be updated in `cloudbuild.yaml`
2. Set up a service account with the relevant roles (if not already):
  1. Cloud Build Service Account
  2. Cloud Run Admin
3. If you are looking to use Firestore as the datasource for you application then this app includes the relevant packages necessary to start. You will need to add the `Firebase Viewer` role to your service and/or local development accounts, as well as having set-up the following dependencies:
  1. A new Firestore database; unless you plan to use an existing one
  2. Firebase for your GCP project (this is required to access data from your Cloud Run application)
  3. If you are using firestore, then you will need to replace `YOUR-PROJECT-ID` in `appsettings.json`

## Local set-up

To authenticate locally, you will first need to install `gcloud` command line interface. When ready, then run `gcloud init`

## Deployment process

The final step of the pipeline is a manual one, on trigger the `cloudbuild.yaml` file is used to initiate and deploy the application. This will:

1. Create an image
2. Send it to Cloud Build
3. Instruct deployment to Cloud Run for use by public domain

In order for this to work you will need to have also set-up the relevant environment variables within your pipeline:

1. `GOOGLE_CLOUD_CREDENTIALS` - this is the service key required to be able to authenticate your service account within the pipeline; enable you to be able to instruct the cloud build
2. `PROJECT_ID` - the ID of the GCP project