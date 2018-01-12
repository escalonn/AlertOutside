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
			dir('LocationAlert/LocationAlert.Client') {
				bat 'dotnet publish --output ../../Package'
			}
		}
		catch (error) {
			slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}console|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\npackage failed:\n`${error}`"
			throw error
		}
	}
	stage('deploy') {
		try {
			bat "msdeploy -verb:sync -source:iisApp=\"C:\\Program Files (x86)\\Jenkins\\workspace\\LocationAlert\\Package\" -dest:iisApp=\"Default Web Site/LocationAlert\",computername=\"${env.MSDEPLOY_COMPUTERNAME}\",username=\"${env.MSDEPLOY_USERNAME}\",password=\"${env.MSDEPLOY_PASSWORD}\",authtype=basic -allowUntrusted -enableRule:AppOffline"
		}
		catch (error) {
			slackSend color: 'danger', message: "[<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}console|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString}]\ndeploy failed:\n`${error}`"
			throw error
		}
	}
}
