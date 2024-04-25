package Main;
import javafx.scene.control.Alert;



public class ErrorHandler 
{
    public static void handleNumberFormatException(NumberFormatException e, String errorText) 
    {
        // Parsing errors:
        Alert _alert = new Alert(Alert.AlertType.ERROR);
        _alert.setTitle("Błąd");
        _alert.setHeaderText(null);
        _alert.setContentText(errorText);

        _alert.showAndWait();
    }
}