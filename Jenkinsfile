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
      dir('LocationAlert/LocationAlert.Test') {
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
		'"C:\\Program Files (x86)\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe" -verb:sync -source:iisApp="C:\\Program Files (x86)\\Jenkins\\workspace\\jenkinsops\\Package\\JenkinsOps\\obj\\Debug\\netcoreapp2.0\\PubTmp\\Out" -dest:iisApp="Default Web Site/LocationAlert" -p:computer= ec2-34-235-132-103.compute-1.amazonaws.com -p:username=Admin -p:"password=uKgWw2?tBT8CVAi74pDybmXvsf@TLbsm"  -enableRule:AppOffline'
    }
    catch (error) {
      slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}console|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\ndeploy failed:\n`${error}`"
      throw error
    }
  }
}
