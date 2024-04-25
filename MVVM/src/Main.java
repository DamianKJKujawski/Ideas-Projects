import Main.ErrorHandler;
import Main.Object2D;
import Main.Object2DViewModel;
import Main.Size;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

import java.util.function.IntConsumer;



public class Main extends Application 
{
    private Object2DViewModel viewModel_;

    public static void main(String[] args) 
    {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) 
    {
        // Init: Model(Person) & ViewModel
        Object2D person = new Object2D("Skrzynka", new Size(2,2));

        // View Model:
        viewModel_ = new Object2DViewModel(person);

        // GUI
        TextField nameTextField_ = new TextField();
        TextField widthTextField_ = new TextField();
        TextField heightTextField_ = new TextField();

        // Bind Text Fields:
        nameTextField_.textProperty().bindBidirectional(viewModel_.nameProperty());
        widthTextField_.textProperty().bindBidirectional(viewModel_.widthProperty());
        heightTextField_.textProperty().bindBidirectional(viewModel_.heightProperty());

        nameTextField_.textProperty().addListener((observable, oldValue, newValue) -> {
            viewModel_.updateName(newValue);
        });

        // Text Fields:
        IntConsumer widthUpdater = value -> viewModel_.updateWidth(value);
        IntConsumer heightUpdater = value -> viewModel_.updateHeight(value);

        addIntegerValidationListener(widthTextField_, widthUpdater);
        addIntegerValidationListener(heightTextField_, heightUpdater);

        VBox root = new VBox();
        root.getChildren().addAll(new Label("Name:"), nameTextField_);
        root.getChildren().addAll(new Label("Width:"), widthTextField_);
        root.getChildren().addAll(new Label("Height:"), heightTextField_);

        // Set Scene:
        Scene _scene = new Scene(root, 300, 200);

        // Display Window:
        primaryStage.setTitle("MVVM Example");
        primaryStage.setScene(_scene);
        primaryStage.show();
    }

    // Add listener:
    private void addIntegerValidationListener(TextField textField, IntConsumer updater) 
    {
        textField.textProperty().addListener((observable, oldValue, newValue) -> 
        {
            try 
            {
                int value = Integer.parseInt(newValue);
                updater.accept(value);
            } catch (NumberFormatException e) {
                ErrorHandler.handleNumberFormatException(e, "Wprowadzona wartość musi być liczbą całkowitą!");
            }
        });
    }
}
