node('master') {
  stage('import') {
    try {
      git 'https://github.com/escalonn/AlertOutside.git'
    }
    catch (error) {
      slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}console|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\nimport failed:\n`${error}`"
      throw error
    }
  }
  stage('build') {
    try {
      dir('LocationAlert') {
        bat 'dotnet build --no-incremental'
      }
    }
    catch (error) {
      slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}console|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\nbuild failed:\n`${error}`"
      throw error
    }
  }
  stage('analyze') {
    try {
      dir('LocationAlert') {
        bat 'SonarQube.Scanner.MSBuild begin /k:ao473840 /n:alertoutside /v:0.1.0'
        bat 'dotnet build --no-incremental'
        bat 'SonarQube.Scanner.MSBuild end'
      }
    }
    catch (error) {
      slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}console|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\nanalyze failed:\n`${error}`"
      throw error
    }
  }
  stage('test') {
    try {
      dir('LocationAlert') {
        bat 'dotnet test'
      }
    }
    catch (error) {
      slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}console|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\ntest failed:\n`${error}`"
      throw error
    }
  }
  stage('package') {
    try {
      dir('LocationAlert') {
        bat 'dotnet publish --output ../Package'
        // bat 'dotnet msbuild /t:Pack /p:outputpath=../Package'
      }
    }
    catch (error) {
      slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}console|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\npackage failed:\n`${error}`"
      throw error
    }
  }
  stage('deploy') {
    try {

    }
    catch (error) {
      slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}console|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\ndeploy failed:\n`${error}`"
      throw error
    }
  }
}
