# Entity Framework 6 �}�o��� (�x�_)

* �ҵ{�W��: Entity Framework 6 �}�o���
* �ҵ{���: 2019�~03��24�� (��)
* �W�Үɶ�: 09:00-17:00
* �W�Ҧa�I: �x�_���j�w�Ϫ��ص�199��5�� (�H���j�ǥx�_�հ� �T�� 325 �Ы�)
* ���ҳ]�w: [Entity Framework 6 �}�o��� ��@���һ���](https://gist.github.com/doggy8088/3359bde0b0425fd89f20bca062333d6a)

## �M�׳]�w�B�J


1. �z�L Git �ƻs���M�� (�����U���]�i�H)

    ```sh
    git clone https://github.com/coolrare/DCT-108010.git
    ```

2. �ϥ� Visual Studio 2017 �}�� `ConsoleApp1.sln` �����

3. ���U `Ctrl-Shift-B` �ظm�M�סA�T�{�ظm�L�~�Y�i�����C

## �إ� ContosoUniversity �d�Ҹ�Ʈw

### �z�L Visual Studio 2017 �إ߸�Ʈw

1. �ƹ������u����`�ޡv���� `ContosoUniversity.sql` �ɮ�

2. �I�� **Connect** �s����Ʈw


    ![image](https://user-images.githubusercontent.com/88981/54868930-d7298380-4dcc-11e9-8fef-99f7412503c3.png)

3. ��� **����** �� **MSSQLLocalDB** ��Ʈw���A���A�ë��U�u�s���v

    ![image](https://user-images.githubusercontent.com/88981/54868956-18ba2e80-4dcd-11e9-8cca-f3e81dfc1522.png)

4. ���U�u����v���s�A��Ʈw�Y�i�إߧ����I

    ![image](https://user-images.githubusercontent.com/88981/54868972-5b7c0680-4dcd-11e9-888e-abc81ae142a8.png)

### �z�L Management Studio (SSMS) �إ߸�Ʈw

1. �z�L Management Studio (SSMS) �s����Ʈw

    * ���A���W��: `(localdb)\MSSQLLocalDB`
    * �ϥΪ�����: **Windows ����**

2. �N `ContosoUniversity.sql` �즲�� SSMS �������ð���

3. ���s��z�u�����`�ޡv������Ʈw�M��A�ݬO�_�X�{ `ContosoUniversity` �d�Ҹ�Ʈw

### �z�L Management Studio (SSMS) �إ߸�Ʈw

1. �}�ҩR�O���ܦr������ (cmd) �öi�J�M�׸�Ƨ�


    ```sh
    cd /d C:\Projects\DCT-108010
    ```

2. ����H�U `osql` �R�O (�Y�S����ܥ�����~�T���A�N�N��إߦ��\)

    ```sh
    osql -E -S "(localdb)\MSSQLLocalDB" -i ContosoUniversity.sql -o nul
    ```

3. �d�� `ContosoUniversity` ��Ʈw�O�_���\�Q�إ�

    ```sh
    osql -E -S "(localdb)\MSSQLLocalDB" -Q "SELECT name FROM sys.databases WHERE name='ContosoUniversity'"
    ``` 