node('master') {
  stage('import') {
    try {
      git 'https://github.com/escalonn/AlertOutside.git'
    }
    catch (error) {
        slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\nimport failed:\n`${error}`"
        throw error
    }
  }
  stage('build') {
    try {

    }
    catch (error) {
        slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\nbuild failed:\n`${error}`"
        throw error
    }
  }
  stage('analyze') {
    try {

    }
    catch (error) {
        slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\nanalyze failed:\n`${error}`"
        throw error
    }
  }
  stage('test') {
    try {

    }
    catch (error) {
        slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\ntest failed:\n`${error}`"
        throw error
    }
  }
  stage('package') {
    try {

    }
    catch (error) {
        slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\npackage failed:\n`${error}`"
        throw error
    }
  }
  stage('deploy') {
    try {

    }
    catch (error) {
        slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\ndeploy failed:\n`${error}`"
        throw error
    }
  }
}
