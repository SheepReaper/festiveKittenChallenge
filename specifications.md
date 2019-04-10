ESCALATE Implant Specifications
-------------------------------

**CONFIDENTIAL: DO NOT DISTRIBUTE**


OVERVIEW
========
The ESCALATE implant communicates with JSON over HTTP. It will periodically check in for tasking, execute one task per check-in, and POST the results back.

The implant can run any Bash command on the host machines. It may also push a file to a given path on the implant. Finally, it may pull a file back from the machine, given a path.


IMPLANT CHECK-INS
=================
The implant will **check in at your IP address on port 5000**. Your listening post should be running there.

GETTING TASKING
===============
To get TASKING, the implant will:
    GET /tasking/<node_id>       Where node_id is the implants unique ID as an integer.

The implant expects the following JSON response:

{
    task_id: integer,
    command: string
}

`command` is any Linux Bash command string. 

Additionally, `command` may be one of:

- "pull /path/to/file/to/pull/from/implant"
- "push /local/file/path /remote/file/path"


SENDING RESULTS
===============
After running a task, the implant will check back in with the results using the following request:

    POST /results/<node_id>    Where node_id is the implant's unique ID as an integer.

In the request, the implant will include the following JSON data:

{
    task_id: integer,
    results: string
}

If an error occurred while executing the tasking, the response will instead be:
{
    task_id: integer,
    error: string
}


PUSHING FILE
============
If the `push` task is issued to an implant, it will issue an additional request to the server to get the file. That request is:

    POST /file/push/<node_id>   Where node_id is the implant's unique ID as an integer.

In the request, the implant will include the following JSON data:
{
   filename: string
}


After execution, the command will send the results of the task back.


PULLING FILE
============
If the `pull` task is issued to an implant, it will issue an additional request to the server to send the file back. That request is:
   
    POST /file/pull/<node_id>   Where node_id is the implant's unique ID as an integer.

In the request, the implant will include the file as a multipart-form in the request.

After execution, the command will send the results of the task back.
