Public Structure _sMsg

    Shared sMsg_Print As String = " 출력이 완료 되었습니다."
    Shared sMsg_Delete As String = " 삭제되었습니다."
    Shared sMsg_Save As String = " 저장되었습니다"
    Shared sMsg_Reroad As String = " 새로고침 되었습니다.."
    Shared sMsg_ProgramStart As String = " 프로그램이 시작 되었습니다."
    Shared sMsg_Error As String = " 프로그램에 오류가 발생 했습니다." & Chr(10) & Chr(10) &
                                  " 시스템 로그 파일을 확인하시기 바랍니다."
    Shared sMsg_NoXML As String = " 해당 xml파일이 존재하지 않습니다."
    Shared sMsg_NoLoad As String = " xml파일 및 정보를 불러오지 못했습니다."
    Shared sMsg_NoTestCode As String = " 등록된 검사코드가 없습니다 !"
    Shared sMsg_NoPw As String = " 비밀번호가 틀렸습니다"
    Shared sMsg_NoID As String = " 등록된 사용자가 아닙니다 !"
    Shared sMsg_NoCh As String = " 채널번호를 선택해 주세요 !"
    Shared sMsg_Exit As String = " 업무가 진행중 입니다." & Chr(10) & Chr(10) &
                                 " 작업을 종료하면 진행 중인 데이터를 잃게 됩니다.   " & Chr(10) & Chr(10) &
                                 " 종료하시겠습니까?"
    Shared sMsg_NoContents As String = "해당되는 사항이 없습니다 !"

End Structure

Public Structure _sMsg_Title

    Shared sMsgTitle_Save As String = "저장 완료"
    Shared sMsgTitle_SaveError As String = "저장 에러"
    Shared sMsgTitle_Reroad As String = "새로고침 완료"
    Shared sMsgTitle_Delete As String = "삭제 완료"
    Shared sMsgTitle_Exit As String = "종료"
    Shared sMsgTitle_Info As String = "안내"
    Shared sMsgTitle_File As String = "파일 에러"
    Shared sMsgTitle_TestCode As String = "검사코드 에러"
    Shared sMsgTitle_NoPw As String = "비밀번호 에러"
    Shared sMsgTitle_NoID As String = "사용자 등록 에러"
    Shared sMsgTitle_Error As String = "에러"

End Structure

Public Structure _sMsg_Question

    Shared sMsgQst_Save As String = "저장 하시겠습니까?"
    Shared sMsgQst_Delete As String = "삭제 하시겠습니까?"
    Shared sMsgQst_Exit As String = " 업무가 진행중 입니다." & Chr(10) & Chr(10) &
                                    " 작업을 종료하면 진행 중인 데이터를 잃게 됩니다.   " & Chr(10) & Chr(10) &
                                    " 종료하시겠습니까?"
    Shared sMsgQst_ServerSave As String = "서버정보를 저장 하시겠습니까?"

End Structure